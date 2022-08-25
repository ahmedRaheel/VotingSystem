using VotingSystem.Application.Candidate;
using VotingSystem.Application.Candidate.Commands;
using VotingSystem.Application.CandidateCategory.Commands;
using VotingSystem.Application.Common.Interfaces;
using VotingSystem.Domain.Entities;
using VotingSystem.Domain.Enum;
using VotingSystem.Infrastructure.Data;

namespace VotingSystem.Infrastructure.Repositories;

/// <summary>
///   CandidateRepository
/// </summary>
public class CandidateRepository : ICandidateRepository
{
    protected readonly VotingSystemContext _dbContext;
    
    /// <summary>
    ///  Constructor
    /// </summary>
    /// <param name="context"></param>
    public CandidateRepository(VotingSystemContext dbContext)
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
    ///  CreateCandidate
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<Candidate> CreateCandidate(CreateCandidateCommand request)
    {
        var candidate = new Candidate
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
            PartyId = request.PartyId            
        };
        _dbContext.Candidate.Add(candidate);

        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(candidate);
    }
    /// <summary>
    /// GetCandidateById
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Candidate GetCandidateById(long Id) => _dbContext.Candidate.FirstOrDefault(x => x.Id == Id);
}