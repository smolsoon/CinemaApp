using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.Infrastrucure.Settings
{
    public static class JWTSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}