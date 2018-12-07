using System;

namespace Cinema.Model.Domain
{
    public abstract class Entity
    {
        public Guid GuidId { get; set; }
        protected Entity()
        {
            GuidId =  Guid.NewGuid();
        }
    }
}