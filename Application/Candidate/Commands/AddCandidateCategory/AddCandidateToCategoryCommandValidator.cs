using FluentValidation;

namespace VotingSystem.Application.Candidate.Commands;
public class AddCandidateToCategoryCommandValidator : AbstractValidator<AddCandidateToCategoryCommand>
{
    public AddCandidateToCategoryCommandValidator()
    {
        RuleFor(x=>x.CandidateId).NotEmpty().WithMessage("CandidateId is required.");
        RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("CategoryId is required.");
    }
}
