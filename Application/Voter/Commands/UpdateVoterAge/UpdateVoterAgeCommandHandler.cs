using MediatR;
using VotingSystem.Application.Common.Exceptions;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.Voter.Commands;
public class UpdateVoterAgeCommandHandler : IRequestHandler<UpdateVoterAgeCommand, int>
{
    private readonly IVoterRepository _repository;
    
    /// <summary>
    ///   Constructor
    /// </summary>
    /// <param name="repository"></param>
    public UpdateVoterAgeCommandHandler(IVoterRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException();
    }
    
    /// <summary>
    ///     Handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(UpdateVoterAgeCommand request, CancellationToken cancellationToken)
    {
        var voter = _repository.GetVoterById(request.VoterId);
        if (voter == null) 
        {
            throw new NotFoundException("Voter was not found.");
        }
        voter.DateOfBirth = request.DateOfBirth;
        return await _repository.UpdateVoterAge(voter);
    }
}
