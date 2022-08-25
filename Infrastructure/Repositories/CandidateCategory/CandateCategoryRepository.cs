using VotingSystem.Application.CandidateCategory.Commands;
using VotingSystem.Application.Common.Interfaces;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enum;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure.Repositories;

/// <summary>
///   CandidateCategoryRepository
/// </summary>
public class CandidateCategoryRepository : ICandidateCategoryRepository
{
    protected readonly VotingSystemContext _dbContext;
    
    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="context"></param>
    public CandidateCategoryRepository(VotingSystemContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    ///     CreateCategory
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<CandidateCategory> CreateCategory(CreateCategoryCommand request)
    {
        var category = new CandidateCategory 
        {
            IsActive = true, 
            CandidateCategoryType = (CandidateCategoryType)request.CategoryType
        };

        await _dbContext.CandidateCategory.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(category);
    }

    /// <summary>
    /// GetCategoryById
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public CandidateCategory GetCategoryById(long Id) => _dbContext.CandidateCategory.FirstOrDefault(x => x.Id == Id);
}