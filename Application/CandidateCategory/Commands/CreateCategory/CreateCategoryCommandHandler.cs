using MediatR;
using Nest;
using VotingSystem.Application.Common.Interfaces;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.CandidateCategory.Commands;

/// <summary>
///     CreateCategoryCommandHandler
/// </summary>
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICandidateCategoryRepository _repository;
    private readonly IElasticClient _elasticClient;
    public CreateCategoryCommandHandler(ICandidateCategoryRepository repository, IElasticClient client)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _elasticClient = client ?? throw new ArgumentNullException();
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response  = await _repository.CreateCategory(request);

        await _elasticClient.IndexDocumentAsync(response);

        return await Task.FromResult((int)response.Id);
    }
}