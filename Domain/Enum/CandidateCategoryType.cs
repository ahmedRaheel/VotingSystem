using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem.Domain.Enum
{
    /// <summary>
    ///     Candidate Category
    /// </summary>
    public enum CandidateCategoryType : int
    {
        /// <summary>
        /// President
        /// </summary>
        President = 1,
        /// <summary>
        /// VicePresident
        /// </summary>
        VicePresident = 2,
        /// <summary>
        /// Secretary
        /// </summary>
        Secretary =3
    }
}
