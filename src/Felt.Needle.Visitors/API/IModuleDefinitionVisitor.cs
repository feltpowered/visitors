using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IModuleDefinitionVisitor : IMemberDefinitionVisitor<ModuleDefinition>
    {
    }
}