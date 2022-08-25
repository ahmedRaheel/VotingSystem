using FluentValidation;

namespace VotingSystem.Application.Voter.Commands;

/// <summary>
///     DeleteVoterCommandValidator
/// </summary>
public class DeleteVoterCommandValidator : AbstractValidator<DeleteVoterCommand>
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public DeleteVoterCommandValidator()
    {
        RuleFor(x => x.VoterId).NotEmpty().WithMessage("VoteId is required.");
    }
}
