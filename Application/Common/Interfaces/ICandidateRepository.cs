using VotingSystem.Application.Candidate.Commands;
using DAL =  VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Common.Interfaces;
public interface ICandidateRepository
{
    Task<DAL.Candidate> CreateCandidate(CreateCandidateCommand request);
    Task<int> AddCandidateToCategory(DAL.Candidate request);    
    DAL.Candidate GetCandidateById(long Id);
}

