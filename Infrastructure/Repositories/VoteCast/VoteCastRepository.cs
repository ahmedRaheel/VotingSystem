using VotingSystem.Application.Common.Interfaces;
using VotingSystem.Application.VoteCast.Commands;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enum;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure.Repositories;

/// <summary>
///   VoteCastRepository
/// </summary>
public class VoteCastRepository : IVoteCastRepository
{
    protected readonly VotingSystemContext _dbContext;
    
    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="context"></param>
    public VoteCastRepository(VotingSystemContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    
    /// <summary>
    ///     CastVote
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<VoteCast> CastVote(CastVoteCommand request)
    {
        var vote = new VoteCast
        {
            IsActive = true, 
            CandidateId = request.CandidateId, 
            VoterId = request.VoterId
        };

        _dbContext.VoteCast.Add(vote);
         await _dbContext.SaveChangesAsync();
         return await Task.FromResult(vote);
    }
    
    /// <summary>
    /// GetVoteCastByVoterId
    /// </summary>
    /// <param name="voterId"></param>
    /// <returns></returns>
    public List<VoteCast> GetVoteCastByVoterId(long voterId)
    {
        return _dbContext.VoteCast.Where(x=>x.VoterId == voterId).ToList();
    }
}