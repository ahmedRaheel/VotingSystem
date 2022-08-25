using VotingSystem.Application.CandidateCategory.Commands;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Common.Interfaces;

public interface ICandidateCategoryRepository 
{
    Task<DAL.CandidateCategory>  CreateCategory(CreateCategoryCommand request);
    DAL.CandidateCategory GetCategoryById(long Id);
}
