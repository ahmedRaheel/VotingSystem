using MediatR;
using Nest;
using VotingSystem.Application.Candidate.Commands;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.Candidate.Commands;

/// <summary>
///     CreateCandidateCommandHandler
/// </summary>
public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
{
    private readonly ICandidateRepository _repository;
    private readonly IElasticClient _elasticClient;


    /// <summary>
    ///     CreateCandidateCommandHandler
    /// </summary>
    /// <param name="repository"></param>
    public CreateCandidateCommandHandler(ICandidateRepository repository, IElasticClient client)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _elasticClient = client ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///     Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var data = await _repository.CreateCandidate(request);
        await  _elasticClient.IndexDocumentAsync(data);
        return await Task.FromResult((int)data.Id);
    }
}