using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.CandidateCategory.Queries;

public interface ICandidateCategoryService 
{
    Task<List<DAL.CandidateCategory>> GetCandidateCategory();
    Task<List<DAL.CandidateCategory>> GetCandidateCategoryById(long Id);
}