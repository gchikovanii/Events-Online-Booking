using ItAcademy.Application.Infrastructure.Errors.CustomExceptions;
using ItAcademy.Application.Infrastructure.Localization.Errors;
using System.Security.Cryptography;
using System.Text;
namespace ItAcademy.Application.Accounts.Helper
{
    public static class PasswordHashGenerator
    {
        //Hash Password By sha 512
        public static string HashPassword(string password)
        {
            using (var s = SHA512.Create())
            {
                var bytes = Encoding.ASCII.GetBytes(password + "Alxamdulila");
                var hashBytes = s.ComputeHash(bytes);
                var stringBuilder = new StringBuilder();
                for (var i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }
                if (string.IsNullOrEmpty(stringBuilder.ToString()))
                    throw new ResultWasEmptyException(ErrorMessages.EmptyString);
                return stringBuilder.ToString();
            }
        }
    }
}
