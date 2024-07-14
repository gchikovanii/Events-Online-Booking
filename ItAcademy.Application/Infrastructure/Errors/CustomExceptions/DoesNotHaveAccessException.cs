namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class DoesNotHaveAccessException : Exception
    {
        public DoesNotHaveAccessException(string message) : base(message)
        {
        }
    }
}
