using MediatR;

namespace VotingSystem.Application.Voter.Commands;
public class UpdateVoterAgeCommand : IRequest<int>
{
    public long VoterId {get;set;}
    public DateTime  DateOfBirth {get;set;}
}