using System;
using Cinema.Infrastrucure.DTO;
using Microsoft.Extensions.Options;

namespace Cinema.Infrastrucure.Settings
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JWTSettings _jwtSettings;
        
         public JwtHandler(IOptions<JWTSettings> jwtSettings)
        {
            _jwtSettings  = jwtSettings.Value;
        }
        public JwtDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            throw new Exception();
        }
    }
}