using FluentValidation;

namespace VotingSystem.Application.CandidateCategory.Commands;

/// <summary>
///     CreateCategoryCommandValidator
/// </summary>
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryType).NotEmpty().WithMessage("Category Type is required.");
    }
}