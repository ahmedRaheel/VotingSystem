using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.VoteCast.Queries;

public interface IVoteCastService 
{
    Task<List<DAL.VoteCast>> GetVotesByCanidate(long candidateId);   
}