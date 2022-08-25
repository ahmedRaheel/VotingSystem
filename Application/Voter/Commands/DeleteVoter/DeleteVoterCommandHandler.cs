using MediatR;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.Voter.Commands;

/// <summary>
///     DeleteVoterCommandHandler
/// </summary>
public class DeleteVoterCommandHandler : IRequestHandler<DeleteVoterCommand, int>
{
    private readonly IVoterRepository _repository;
    /// <summary>
    ///  Constructor
    /// </summary>
    public DeleteVoterCommandHandler(IVoterRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///   Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(DeleteVoterCommand request, CancellationToken cancellationToken)
    {
        var voter = _repository.GetVoterById(request.VoterId);
        if (voter == null)
              throw new ArgumentNullException("VoterId is not valid.");

        return await _repository.DeleteVoter(voter);
    }
}
