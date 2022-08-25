using VotingSystem.Application.Voter.Commands;
using DAL = VotingSystem.Domain.Entities;


namespace VotingSystem.Application.Common.Interfaces;
public interface IVoterRepository
{
    Task<DAL.Voter> CreateVoter(CreateVoterCommand request);
    Task<int> DeleteVoter(DAL.Voter request);
    Task<int> UpdateVoterAge(DAL.Voter request);
    DAL.Voter GetVoterById (long Id);
}