using System;
using VotingSystem.Domain.Common;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Domain.Entities
{
    public class VoterContact: BaseAuditableEntity
    {
        #region Field

        /// <summary>
        ///     VoterId Property
        /// </summary>
        public long VoterId { get; set; }
        
        /// <summary>
        ///     Voter Property
        /// </summary>
        public Voter Voter { get; set; }

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
