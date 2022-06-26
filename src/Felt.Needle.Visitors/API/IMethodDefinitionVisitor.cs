using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IMethodDefinitionVisitor : IMemberDefinitionVisitor<MethodDefinition>
    {
    }
}