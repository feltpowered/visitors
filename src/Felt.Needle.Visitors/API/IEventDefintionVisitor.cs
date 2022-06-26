using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IEventDefinitionVisitor : IMemberDefinitionVisitor<EventDefinition>
    {
    }
}