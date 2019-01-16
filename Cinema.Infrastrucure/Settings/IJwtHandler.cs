using System;
using Cinema.Infrastrucure.DTO;
using MongoDB.Bson;

namespace Cinema.Infrastrucure.Settings
{
    public interface IJwtHandler
    {
         JwtDTO CreateToken(ObjectId userId, string role);
    }
}