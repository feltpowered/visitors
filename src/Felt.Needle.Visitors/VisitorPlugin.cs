using System.Collections;
using Felt.Needle.API;
using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    /// <summary>
    ///     Implementation of <see cref="ICecilPlugin"/> for visiting definitions.
    /// </summary>
    public class VisitorPlugin : ICecilPlugin, IList<IMemberDefinitionVisitor>
    {
        protected readonly List<IMemberDefinitionVisitor> Visitors = new();

        public virtual void TransformModule(ModuleDefinition module) {
            foreach (IMemberDefinitionVisitor visitor in Visitors) VisitModule(module, visitor);
        }

        protected virtual void VisitModule(ModuleDefinition module, IMemberDefinitionVisitor visitor) {
            DoVisit(module, visitor);
            DoVisit(module.Assembly, visitor);

            static void RecurseType(TypeDefinition type, ICollection<TypeDefinition> types) {
                types.Add(type);

                if (!type.HasNestedTypes) return;

                foreach (TypeDefinition nestedType in type.NestedTypes) RecurseType(nestedType, types);
            }

            ICollection<TypeDefinition> types = new List<TypeDefinition>();
            foreach (TypeDefinition type in module.Types) {
                RecurseType(type, types);
            }

            foreach (TypeDefinition type in types) {
                DoVisit(type, visitor);

                // Methods
                foreach (MethodDefinition method in type.Methods) {
                    DoVisit(method, visitor);

                    // Parameters
                    foreach (ParameterDefinition parameter in method.Parameters) {
                        DoVisit(parameter, visitor);
                    }
                }

                // Fields
                foreach (FieldDefinition field in type.Fields) {
                    DoVisit(field, visitor);
                }

                // Events
                foreach (EventDefinition @event in type.Events) {
                    DoVisit(@event, visitor);
                }

                // Properties
                foreach (PropertyDefinition property in type.Properties) {
                    DoVisit(property, visitor);
                }
            }
        }

        protected virtual void DoVisit(object definition, IMemberDefinitionVisitor visitor) {
            if (visitor.CanVisit(definition)) visitor.Visit(definition);
        }

        #region IList<IMemberDefinitionVisitor> Impl

        IEnumerator<IMemberDefinitionVisitor> IEnumerable<IMemberDefinitionVisitor>.GetEnumerator() {
            return Visitors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IList<IMemberDefinitionVisitor>) this).GetEnumerator();
        }

        void ICollection<IMemberDefinitionVisitor>.Add(IMemberDefinitionVisitor item) {
            Visitors.Add(item);
        }

        void ICollection<IMemberDefinitionVisitor>.Clear() {
            Visitors.Clear();
        }

        bool ICollection<IMemberDefinitionVisitor>.Contains(IMemberDefinitionVisitor item) {
            return Visitors.Contains(item);
        }

        void ICollection<IMemberDefinitionVisitor>.CopyTo(IMemberDefinitionVisitor[] array, int arrayIndex) {
            Visitors.CopyTo(array, arrayIndex);
        }

        bool ICollection<IMemberDefinitionVisitor>.Remove(IMemberDefinitionVisitor item) {
            return Visitors.Remove(item);
        }

        int ICollection<IMemberDefinitionVisitor>.Count => Visitors.Count;

        bool ICollection<IMemberDefinitionVisitor>.IsReadOnly => ((IList<IMemberDefinitionVisitor>) Visitors).IsReadOnly;

        int IList<IMemberDefinitionVisitor>.IndexOf(IMemberDefinitionVisitor item) {
            return Visitors.IndexOf(item);
        }

        void IList<IMemberDefinitionVisitor>.Insert(int index, IMemberDefinitionVisitor item) {
            Visitors.Insert(index, item);
        }

        void IList<IMemberDefinitionVisitor>.RemoveAt(int index) {
            Visitors.RemoveAt(index);
        }

        IMemberDefinitionVisitor IList<IMemberDefinitionVisitor>.this[int index] {
            get => Visitors[index];
            set => Visitors[index] = value;
        }

        #endregion

        #region Reimpl

        public virtual void AddVisitor(IMemberDefinitionVisitor item) {
            ((IList<IMemberDefinitionVisitor>) this).Add(item);
        }

        public virtual void ClearVisitors() {
            ((IList<IMemberDefinitionVisitor>) this).Clear();
        }

        public virtual bool ContainsVisitor(IMemberDefinitionVisitor item) {
            return ((IList<IMemberDefinitionVisitor>) this).Contains(item);
        }

        public virtual bool RemoveVisitor(IMemberDefinitionVisitor item) {
            return ((IList<IMemberDefinitionVisitor>) this).Remove(item);
        }

        public virtual int VisitorCount => Visitors.Count;

        public virtual int IndexOfVisitor(IMemberDefinitionVisitor item) {
            return ((IList<IMemberDefinitionVisitor>) this).IndexOf(item);
        }

        public virtual void InsertVisitor(int index, IMemberDefinitionVisitor item) {
            ((IList<IMemberDefinitionVisitor>) this).Insert(index, item);
        }

        public virtual void RemoveVisitorAt(int index) {
            ((IList<IMemberDefinitionVisitor>) this).RemoveAt(index);
        }

        #endregion
    }
}