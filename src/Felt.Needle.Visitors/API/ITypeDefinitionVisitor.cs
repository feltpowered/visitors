using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface ITypeDefinitionVisitor : IMemberDefinitionVisitor<TypeDefinition>
    {
    }
}