using VotingSystem.Domain.Common;

namespace VotingSystem.Domain.Entities
{
    public class City : BaseAuditableEntity
    {
        #region Field
        /// <summary>
        ///     Code Property
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Name Property 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  StateId Property
        /// </summary>
        public long StateId { get; set; }

        /// <summary>
        ///    State Property
        /// </summary>
        public State State { get; set; } 
        #endregion
    }
}
