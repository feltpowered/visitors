using Felt.Needle.Visitors.API;
using Mono.Cecil;

namespace Felt.Needle.Visitors
{
    public abstract class AssemblyDefinitionVisitor : IAssemblyDefinitionVisitor
    {
        public virtual bool CanVisit(in AssemblyDefinition memberDefinition) {
            return true;
        }

        public abstract void Visit(AssemblyDefinition memberDefinition);
    }
}