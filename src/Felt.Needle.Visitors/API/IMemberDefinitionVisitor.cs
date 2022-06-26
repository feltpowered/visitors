namespace Felt.Needle.Visitors.API
{
    /// <summary>
    ///     Visits a member definition;
    /// </summary>
    /// <typeparam name="TDefinition"></typeparam>
    public interface IMemberDefinitionVisitor<TDefinition> : IMemberDefinitionVisitor
    {
        /// <summary>
        ///     Determines if this object may visit the given member definition.
        /// </summary>
        /// <param name="memberDefinition">The member definition to check visibility for.</param>
        /// <returns>Whether this member definition may be visited.</returns>
        bool CanVisit(in TDefinition memberDefinition);

        /// <summary>
        ///     Visits a member definition, allowing this visitor to apply arbitrary changes.
        /// </summary>
        /// <param name="memberDefinition">The member definition to visit.</param>
        void Visit(TDefinition memberDefinition);

        bool IMemberDefinitionVisitor.CanVisit(in object memberDefinition) {
            return memberDefinition is TDefinition def && CanVisit(def);
        }

        void IMemberDefinitionVisitor.Visit(object memberDefinition) {
            Visit((TDefinition) memberDefinition);
        }
    }
    
    /// <summary>
    ///     Visits a member definition.
    /// </summary>
    public interface IMemberDefinitionVisitor
    {
        /// <summary>
        ///     Determines if this object may visit the given member definition.
        /// </summary>
        /// <param name="memberDefinition">The member definition to check visibility for.</param>
        /// <returns>Whether this member definition may be visited.</returns>
        bool CanVisit(in object memberDefinition);

        /// <summary>
        ///     Visits a member definition, allowing this visitor to apply arbitrary changes.
        /// </summary>
        /// <param name="memberDefinition">The member definition to visit.</param>
        void Visit(object memberDefinition);
    }
}