using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Voter.Queries;

public interface IVoterService 
{
    Task<List<DAL.Voter>> GetVoters();   
}