using VotingSyste.API.Model;

namespace VotingSystem.API.Model
{
    public class ExceptionResponse : APIResponse
    {
        public ExceptionResponse(int StatusCode, string message = null,string details=null) : base(StatusCode, message)
        {
            details = details;
        }
        public string Details { get; set; }
    }
}