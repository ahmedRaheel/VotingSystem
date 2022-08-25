using MediatR;

namespace VotingSystem.Application.Candidate.Commands;
public class AddCandidateToCategoryCommand  : IRequest<int>
{
    public long CategoryId { get; set; }
    public long CandidateId { get; set; }
}
