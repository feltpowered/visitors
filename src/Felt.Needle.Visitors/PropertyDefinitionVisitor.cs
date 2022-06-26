using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class PropertyDefinitionVisitor : IPropertyDefinitionVisitor
    {
        public virtual bool CanVisit(in PropertyDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(PropertyDefinition memberDefinition);
    }
}