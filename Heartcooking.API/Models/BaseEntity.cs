using System;

namespace Heartcooking.API.Models
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}