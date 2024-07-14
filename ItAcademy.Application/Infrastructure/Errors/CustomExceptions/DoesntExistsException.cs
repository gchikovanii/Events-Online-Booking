namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class DoesntExistsException : Exception
    {
        public DoesntExistsException(string message) : base(message)
        {
        }
    }
}
