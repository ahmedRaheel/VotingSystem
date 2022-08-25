using MediatR;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Application.Candidate.Commands;
public class CreateCandidateCommand : IRequest<int>
{    
    #region Fields
    /// <summary>
    ///  FirstName Property
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///  LastName Property
    /// </summary>
    public string LastName { get; set; } 

    /// <summary>
    ///  GenderType  Property
    /// </summary>
    public GenderType GenderType { get; set; }
    /// <summary>
    ///     DateOfBirth Property
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    ///     FatherName Property 
    /// </summary>
    public string FatherName { get; set; }
    /// <summary>
    ///     CNIC Property
    /// </summary>
    public string CNIC { get; set; }

    /// <summary>
    ///     HomePhone Property
    /// </summary>
    public string HomePhone { get; set; }

    /// <summary>
    ///     MobileNumber Property
    /// </summary>
    public string MobileNumber { get; set; }
    /// <summary>
    ///  PartyId Property
    /// </summary>
    public long PartyId { get; set; }    

    #endregion
}

