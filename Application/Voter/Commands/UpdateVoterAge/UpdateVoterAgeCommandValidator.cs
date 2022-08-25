using FluentValidation;

namespace VotingSystem.Application.Voter.Commands;
public class UpdateVoterAgeCommandValidator : AbstractValidator<UpdateVoterAgeCommand>
{
    public UpdateVoterAgeCommandValidator()
    {
        RuleFor (x => x.VoterId).NotEmpty().WithMessage("VoterId is required.");
        RuleFor(x=>x.DateOfBirth).Must(ValidateAge).WithMessage("Voter age should be over 18.");
    }

     /// <summary>
    ///    ValidateAge
    /// </summary>
    /// <param name="dateOfBirth"></param>
    /// <returns></returns>
    public bool ValidateAge(DateTime dateOfBirth)
    {
        var datedifference = DateTime.Now.Year - dateOfBirth.Year;
        return datedifference >= 18 ? true : false;
    }
}
