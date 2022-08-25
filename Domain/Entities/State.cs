using System.Collections.Generic;
using VotingSystem.Domain.Common;

namespace VotingSystem.Domain.Entities
{
    public class State : BaseAuditableEntity
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

        /// <summary>
        ///  Cities
        /// </summary>
        public ICollection<City> Cities { get; set; } 

        
        #endregion
    }
}
