using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Model.Domain
{
    public class Entity
    {
        [BsonId]
        public ObjectId Id { get; protected set; }

        protected Entity()
        {
            Id = new ObjectId();
        }
    }
}