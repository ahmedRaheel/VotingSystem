using System;

namespace VotingSystem.Domain.Common
{
    /// <summary>
    ///  Base entity for auditable object
    /// </summary>
    public class BaseAuditableEntity : BaseEntity
    {
        #region Fields
        /// <summary>
        ///  Created Datetime
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        ///     CreatedBy
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        ///   LastModified  
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        ///     LastModifiedBy
        /// </summary>
        public string? LastModifiedBy { get; set; } 
        #endregion
    }
}
