using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class FieldDefinitionVisitor : IFieldDefinitionVisitor
    {
        public virtual bool CanVisit(in FieldDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(FieldDefinition memberDefinition);
    }
}