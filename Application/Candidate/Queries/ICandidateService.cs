using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Candidate.Queries;

public interface ICandidateService 
{
    Task<List<DAL.Candidate>> GetCandidates();
    Task<List<DAL.Candidate>> GetCandidateById(long Id);
}