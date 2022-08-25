using System.Collections.Generic;
using VotingSystem.Domain.Common;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Domain.Entities
{
    /// <summary>
    ///  Candidate Entity
    /// </summary>
    public class Candidate : BaseAuditableEntity
    {
        #region Fields
        /// <summary>
        ///  FirstName Property
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///  LastName Property
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  GenderType  Property
        /// </summary>
        public GenderType GenderType { get; set; }
        /// <summary>
        ///     DateOfBirth Property
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        ///     FatherName Property 
        /// </summary>
        public string FatherName { get; set; }
         /// <summary>
        ///     CNIC Property
        /// </summary>
        public string CNIC { get; set; }

        /// <summary>
        ///     HomePhone Property
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        ///     MobileNumber Property
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        ///  PartyId Property
        /// </summary>
        public long PartyId { get; set; }

        /// <summary>
        ///     Party Property
        /// </summary>
        public Party Party { get; set; }

        /// <summary>
        ///   CandidateCategoryId  Property
        /// </summary>
        public long? CandidateCategoryId { get; set; }

        /// <summary>
        ///    CandidateCategory  Property
        /// </summary>
        public CandidateCategory? CandidateCategory { get; set; }

        /// <summary>
        ///   CandidateContacts
        /// </summary>
        public ICollection<CandidateContact> CandidateContacts { get; set; }

        /// <summary>
        ///     Votes Property
        /// </summary>         
        public ICollection<VoteCast> Votes { get; set; }

        #endregion
    }
}
