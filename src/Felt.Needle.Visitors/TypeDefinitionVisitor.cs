using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class TypeDefinitionVisitor : ITypeDefinitionVisitor
    {
        public virtual bool CanVisit(in TypeDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(TypeDefinition memberDefinition);
    }
}