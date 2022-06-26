using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IAssemblyDefinitionVisitor : IMemberDefinitionVisitor<AssemblyDefinition>
    {
    }
}