using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Cinema.Model.Domain
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; protected set; }

        protected Entity()
        {
            _id = ObjectId.GenerateNewId();
        }
    }
}