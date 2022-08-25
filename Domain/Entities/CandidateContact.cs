using VotingSystem.Domain.Common;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Domain.Entities
{
    public class CandidateContact : BaseAuditableEntity
    {
        #region Field

        /// <summary>
        ///     CondidateId Property
        /// </summary>
        public long CondidateId { get; set; }

        /// <summary>
        ///     Candidate Property
        /// </summary>
        public Candidate Candidate { get; set; }

        /// <summary>
        ///     AddressLine Property
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        ///    AddressType Property
        /// </summary>
        public AddressType AddressType { get; set; }

        /// <summary>
        ///   CityId Property
        /// </summary>
        public long CityId { get; set; }      

        /// <summary>
        ///     StateID Property
        /// </summary>
        public long StateId { get; set; }       

        #endregion
    }
}
