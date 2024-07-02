namespace BookMe.Application.Exceptions;
public class ConcurencyException : Exception
{
    public ConcurencyException(string message, Exception innerException):base(message, innerException)
    {
    }
}
