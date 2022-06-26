using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class ModuleDefinitionVisitor : IModuleDefinitionVisitor
    {
        public virtual bool CanVisit(in ModuleDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(ModuleDefinition memberDefinition);
    }
}