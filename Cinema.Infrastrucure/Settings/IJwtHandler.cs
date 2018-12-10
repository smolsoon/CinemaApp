using System;
using Cinema.Infrastrucure.DTO;

namespace Cinema.Infrastrucure.Settings
{
    public interface IJwtHandler
    {
         JwtDTO CreateToken(Guid userId, string role);
    }
}