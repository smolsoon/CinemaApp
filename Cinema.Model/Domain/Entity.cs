using System;

namespace Cinema.Model.Domain
{
    public class Entity
    {
        public Guid Idd { get; protected set; }

        protected Entity()
        {
            Idd = Guid.NewGuid();
        }
    }
}