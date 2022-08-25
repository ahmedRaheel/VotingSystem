using MediatR;
using Nest;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.Voter.Commands;

/// <summary>
///     CreateVoterCommandHandler
/// </summary>
public class CreateVoterCommandHandler : IRequestHandler<CreateVoterCommand, int>
{
    private readonly IVoterRepository _respository;
    private readonly IElasticClient _elasticClient;


    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="repository"></param>
    public CreateVoterCommandHandler(IVoterRepository repository, IElasticClient client)
    {
        _respository = repository ?? throw new ArgumentNullException();
        _elasticClient = client ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///  Handle
    /// </summary>
    /// <value></value>
    public async Task<int> Handle(CreateVoterCommand request, CancellationToken cancellationToken)
    {
        var data =  await _respository.CreateVoter(request);
        await _elasticClient.IndexDocumentAsync(data);
        return await Task.FromResult((int) data.Id);
    } 
}
