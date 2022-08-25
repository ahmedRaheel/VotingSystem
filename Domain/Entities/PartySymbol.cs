using VotingSystem.Domain.Common;

namespace VotingSystem.Domain.Entities
{
    public class PartySymbol: BaseAuditableEntity
    {
        #region Fields

        /// <summary>
        ///     Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        public string Name { get; set; }
       
        #endregion
    }
}
