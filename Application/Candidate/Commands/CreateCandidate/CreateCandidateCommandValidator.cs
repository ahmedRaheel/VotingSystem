using System.Data;
using FluentValidation;
using VotingSystem.Application.Candidate.Commands;

namespace application.Candidate.Commands.CreateCandidate;
public class CreateCandidateCommandValidator : AbstractValidator<CreateCandidateCommand>
{
    public CreateCandidateCommandValidator()
    {
        RuleFor(x=>x.FirstName).NotNull().WithMessage("FirstName is required.");
        RuleFor(x=>x.LastName).NotNull().WithMessage("LastName is required.");
        RuleFor(x=>x.PartyId).NotEmpty().WithMessage("PartyId is required.");
        RuleFor(x=>x.CNIC).NotEmpty().MaximumLength(13).WithMessage("CNIC is not valid.");
        RuleFor(x=>x.GenderType).NotEmpty().WithMessage("GenderType is required.");
        RuleFor(x=>x.DateOfBirth).Must(ValidateAge).WithMessage("Candidate age should be over 25.");
    }

    public bool ValidateAge(DateTime dateOfBirth)
    {
        var datedifference = DateTime.Now.Year - dateOfBirth.Year;
        return datedifference >= 25 ? true : false;
    }
}
