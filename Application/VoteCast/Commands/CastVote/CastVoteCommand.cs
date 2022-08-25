using MediatR;

namespace VotingSystem.Application.VoteCast.Commands;
public class CastVoteCommand : IRequest<int>
{
    public long CandidateId { get; set;}
    public long VoterId     { get; set; }
    public long CategoryId   { get;set;}
}
