using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CloudSecurity.Web
{
    public class AuthOptions
    {
        public const string ISSUER = "CloudSecurotyAuthServer"; //издатель токена
        public const string AUDIENCE = "http://0.0.0.0:5106"; //потребитель токена (адрес приложения)
        private const string KEY = "supersecret_seckretkey!cloud_security";//ключ для шифрации
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
