using MediatR;

namespace VotingSystem.Application.Voter.Commands;
public class DeleteVoterCommand : IRequest<int>
{
    public long VoterId { get; set;}
}
