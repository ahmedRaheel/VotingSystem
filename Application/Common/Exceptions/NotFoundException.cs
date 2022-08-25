namespace VotingSystem.Application.Common.Exceptions;

/// <summary>
///     NotFoundException
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    ///     Constructor
    /// </summary>
    public NotFoundException()
        : base()
    {
    }
    
    /// <summary>
    ///   Contructor Overload
    /// </summary>
    /// <param name="message"></param>
    public NotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    ///     Contructor Overload
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    ///     Contructor Overload
    /// </summary>
    /// <param name="name"></param>
    /// <param name="key"></param>
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}
