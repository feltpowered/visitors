using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class MethodDefinitionVisitor : IMethodDefinitionVisitor
    {
        public virtual bool CanVisit(in MethodDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(MethodDefinition memberDefinition);
    }
}