using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IParameterDefinitionVisitor : IMemberDefinitionVisitor<ParameterDefinition>
    {
    }
}