using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Domain.Common;

namespace VotingSystem.Domain.Entities
{
    public class VoteCast :  BaseAuditableEntity
    {
        public long CandidateId { get; set; }
        public Candidate Candidate { get; set; }
        public long VoterId { get; set; }
        public Voter Voter { get; set; }        
    }
}
