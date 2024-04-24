using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace BusinessLogic.Common.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "ChatService"; // издатель токена
        public const string AUDIENCE = "WalletAppClient"; // потребитель токена
        const string KEY = "wg4etwetweg4t4w5tySG4egrdE4gdreg5^&$fgh5%!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
