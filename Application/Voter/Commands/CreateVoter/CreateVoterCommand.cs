using MediatR;
using VotingSystem.Domain.Enum;

namespace VotingSystem.Application.Voter.Commands;
public class CreateVoterCommand : IRequest<int>
{
    #region Field
    /// <summary>
    ///  FirstName Property
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// LastName Property
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///  GenderType
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

        
    #endregion
}