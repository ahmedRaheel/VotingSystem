namespace VotingSystem.Domain.Common
{
    /// <summary>
    ///     Base Entity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Id Property
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// IsActive Property
        /// </summary>
        public bool IsActive { get; set; }        
    }
}
