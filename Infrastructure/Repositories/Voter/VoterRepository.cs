using VotingSystem.Application.Candidate;
using VotingSystem.Application.Candidate.Commands;
using VotingSystem.Application.CandidateCategory.Commands;
using VotingSystem.Application.Common.Interfaces;
using VotingSystem.Application.Voter.Commands;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enum;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure.Repositories;

/// <summary>
///   VoterRepository
/// </summary>
public class VoterRepository : IVoterRepository
{
    protected readonly VotingSystemContext _dbContext;
    
    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="context"></param>
    public VoterRepository(VotingSystemContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }  

    /// <summary>
    ///     AddCandidateToCategory
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<int> AddCandidateToCategory(Candidate request)
    {
        _dbContext.Candidate.Update(request);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    ///     CreateVoter
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<Voter> CreateVoter(CreateVoterCommand request)
    {
        var voter = new Voter
        {
            FirstName = request.FirstName,
            LastName = request.LastName, 
            FatherName = request.FatherName, 
            CNIC = request.CNIC,
            DateOfBirth =  request.DateOfBirth,
            MobileNumber = request.MobileNumber, 
            HomePhone = request.HomePhone, 
            IsActive = true, 
            GenderType = (GenderType)request.GenderType,                    
        };
        _dbContext.Voter.Add(voter);
        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(voter);
    }

    /// <summary>
    ///     DeleteVoter
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<int> DeleteVoter(Voter request)
    {
        _dbContext.Voter.Remove(request);
        return await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    ///     GetVoterById
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Voter GetVoterById(long Id) => _dbContext.Voter.FirstOrDefault(x => x.Id == Id);

    /// <summary>
    ///     UpdateVoterAge
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<int> UpdateVoterAge(Voter request)
    {
        _dbContext.Voter.Update(request);
        return _dbContext.SaveChangesAsync();
    }
}