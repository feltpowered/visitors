using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class EventDefinitionVisitor : IEventDefinitionVisitor
    {
        public virtual bool CanVisit(in EventDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(EventDefinition memberDefinition);
    }
}