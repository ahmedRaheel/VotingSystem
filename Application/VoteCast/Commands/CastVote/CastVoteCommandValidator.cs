using FluentValidation;
using VotingSystem.Application.Common.Interfaces;

namespace VotingSystem.Application.VoteCast.Commands;
public class CastVoteCommandValidator : AbstractValidator<CastVoteCommand>
{
    public CastVoteCommandValidator()
    {
        RuleFor(x=>x.CandidateId).NotEmpty().WithMessage("CandidateId is required.");        
        RuleFor(x=>x.VoterId).NotEmpty().WithMessage("VoteId is required.");        
        RuleFor(x=>x.CandidateId).NotEmpty().WithMessage("CategoryId is required.");
    }
}
