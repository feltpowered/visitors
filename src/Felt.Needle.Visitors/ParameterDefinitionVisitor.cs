using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class ParameterDefinitionVisitor : IParameterDefinitionVisitor
    {
        public virtual bool CanVisit(in ParameterDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(ParameterDefinition memberDefinition);
    }
}