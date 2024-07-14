namespace ItAcademy.Application.Infrastructure.Errors.CustomExceptions
{
    public class SaveToDbException : Exception
    {
        public SaveToDbException(string message) : base(message)
        {
        }
    }
}
