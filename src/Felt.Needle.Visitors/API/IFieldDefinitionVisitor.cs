using Mono.Cecil;

namespace Felt.Needle.Visitors.API
{
    public interface IFieldDefinitionVisitor : IMemberDefinitionVisitor<FieldDefinition>
    {
    }
}