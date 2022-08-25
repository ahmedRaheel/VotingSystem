using VotingSystem.Application.VoteCast.Commands;
using DAL = VotingSystem.Domain.Entities;

namespace VotingSystem.Application.Common.Interfaces;
public interface IVoteCastRepository
{
    Task<DAL.VoteCast> CastVote(CastVoteCommand request); 
     List<DAL.VoteCast>  GetVoteCastByVoterId (long voterId);
}