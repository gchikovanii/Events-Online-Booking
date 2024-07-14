namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string message) : base(message)
        {
        }
    }
}
