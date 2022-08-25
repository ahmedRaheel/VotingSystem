using System.Collections.Generic;
using VotingSystem.Domain.Common;

namespace VotingSystem.Domain.Entities
{
    public class Party : BaseAuditableEntity
    {
        /// <summary>
        ///     FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     ShortName
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        ///     SymbolID Property
        /// </summary>
        public long PartySymbolId { get; set; }

        /// <summary>
        ///      PartySymbol Property
        /// </summary>
        public PartySymbol PartySymbol { get; set; }

        /// <summary>
        ///     Candidates Property
        /// </summary>
        public ICollection<Candidate> Candidates { get; set; }
    }
}
