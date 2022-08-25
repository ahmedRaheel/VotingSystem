using System;
using System.Collections.Generic;
using VotingSystem.Domain.Common;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Domain.Entities
{
    /// <summary>
    /// Voter 
    /// </summary>
    public class Voter : BaseAuditableEntity
    {
        #region Field
        /// <summary>
        ///  FirstName Property
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName Property
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///  GenderType
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
        ///     VoteCast
        /// </summary>
        public ICollection<VoteCast> VoteCast { get; set; }
        #endregion
    }
}
