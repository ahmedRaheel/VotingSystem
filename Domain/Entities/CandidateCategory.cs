using System.Collections.Generic;
using VotingSystem.Domain.Common;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Domain.Entities
{
    /// <summary>
    ///  Candidate Category 
    /// </summary>
    public class CandidateCategory  : BaseAuditableEntity
    {
        #region Field
        /// <summary>
        /// CandidateCategoryType 
        /// </summary>
        public CandidateCategoryType CandidateCategoryType { get; set; }

        /// <summary>
        ///  Candidates Property
        /// </summary>
        public ICollection<Candidate> Candiates { get; set; } 
        #endregion
    }
}
