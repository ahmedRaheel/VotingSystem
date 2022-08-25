using MediatR;
using Nest;
using VotingSystem.Application.Common.Exceptions;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.VoteCast.Commands;
/// <summary>
///     CastVoteCommandHandler
/// </summary>
public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, int>
{
    private readonly IVoteCastRepository _repository;
    private readonly IVoterRepository _voterRepository;
    private readonly ICandidateRepository _candidateRepository;
    private readonly IElasticClient _elasticClient;


    /// <summary>
    ///     CastVoteCommandHandler
    /// </summary>
    /// <param name="repository"></param>
    public CastVoteCommandHandler(IVoteCastRepository repository, IVoterRepository voterRepository,
                               ICandidateRepository candidateRepository, IElasticClient client)
    {
        _repository = repository ?? throw new ArgumentNullException();
        _voterRepository = voterRepository ?? throw new ArgumentNullException();
        _candidateRepository = candidateRepository ?? throw new ArgumentNullException();
        _elasticClient = client ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///     Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(CastVoteCommand request, CancellationToken cancellationToken)
    {
        var voter = _voterRepository.GetVoterById(request.VoterId);
        if (voter == null) 
                throw new NotFoundException("Voter was not found or VoterId is invalid");

        var candidate = _candidateRepository.GetCandidateById(request.CandidateId);
        if (candidate == null) 
                throw new NotFoundException("Candidate was not found or CandidateId is not valid");
        var voteCastList = _repository.GetVoteCastByVoterId(request.VoterId);
        if (voteCastList == null || !voteCastList.Any(x=>x.CandidateId == candidate.Id))
        {
            return await InsertVote(request);
        }


        if (voteCastList.Any(x=>x.CandidateId == candidate.Id))
            throw new NotFoundException("You have already voted for same category.");         
        
        return await InsertVote(request);
    }

    private async Task<int> InsertVote(CastVoteCommand request)
    {
        var data = await _repository.CastVote(request);
        await _elasticClient.IndexDocumentAsync(data);
        return await Task.FromResult((int)data.Id);
    }
}