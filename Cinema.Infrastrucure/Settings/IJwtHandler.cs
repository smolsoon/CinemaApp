using System;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Settings
{
    public interface IJwtHandler
    {
         JwtDTO CreateToken(Guid userId, string role);
    }
}