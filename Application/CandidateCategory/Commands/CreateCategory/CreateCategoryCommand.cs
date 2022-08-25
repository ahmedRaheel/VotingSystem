using MediatR;

namespace VotingSystem.Application.CandidateCategory.Commands;
public class CreateCategoryCommand : IRequest<int>
{
     public int CategoryType { get;set; }
}