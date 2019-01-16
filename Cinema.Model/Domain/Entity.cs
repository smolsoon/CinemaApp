using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Cinema.Model.Domain
{
    public class Entity
    {
        [BsonId]
        public ObjectId _id { get; protected set; }

        public Entity()
        {
            _id = ObjectId.GenerateNewId();
        }
    }
}