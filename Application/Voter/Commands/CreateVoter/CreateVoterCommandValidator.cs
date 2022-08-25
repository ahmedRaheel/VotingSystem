using FluentValidation;

namespace VotingSystem.Application.Voter.Commands;

/// <summary>
///     CreateVoterCommandValidator
/// </summary>
public class CreateVoterCommandValidator : AbstractValidator<CreateVoterCommand>
{
    /// <summary>
    ///   Constructor
    /// </summary>
    public CreateVoterCommandValidator()
    {
        RuleFor(x=>x.FirstName).NotNull().WithMessage("FirstName is required.");
        RuleFor(x=>x.LastName).NotNull().WithMessage("LastName is required.");      
        RuleFor(x=>x.CNIC).NotEmpty().MaximumLength(13).WithMessage("CNIC is not valid.");
        RuleFor(x=>x.GenderType).NotEmpty().WithMessage("GenderType is required.");
        RuleFor(x=>x.DateOfBirth).Must(ValidateAge).WithMessage("Candidate age should be over 18.");
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