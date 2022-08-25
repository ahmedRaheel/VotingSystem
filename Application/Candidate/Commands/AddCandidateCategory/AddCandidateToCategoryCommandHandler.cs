using MediatR;
using VotingSystem.Application.Common.Exceptions;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.Candidate.Commands;
public class AddCandidateToCategoryCommandHandler : IRequestHandler<AddCandidateToCategoryCommand, int>
{
    private readonly ICandidateRepository _repository;
    private readonly ICandidateCategoryRepository _categoryRepositry;

    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="categoryRepository"></param>
    public AddCandidateToCategoryCommandHandler(ICandidateRepository repository
          , ICandidateCategoryRepository categoryRepository)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _categoryRepositry = categoryRepository ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///     Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(AddCandidateToCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _categoryRepositry.GetCategoryById(request.CategoryId);
        if (category == null) 
        {
            throw new NotFoundException("Category was not found.");
        }

        var candidate = _repository.GetCandidateById(request.CandidateId);
        if (candidate == null) 
        {
            throw new NotFoundException("Candidate was not found.");
        }
        if (candidate.CandidateCategoryId == request.CategoryId)
        {
            throw new Exception("Candidate already have assign same category");
        }

        candidate.CandidateCategoryId = request.CategoryId;
        return await _repository.AddCandidateToCategory(candidate);
    }
}
