using BookStore.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Domain.Entities
{
    public abstract class Entity<T> : IEntity where T : Entity<T>
    {
        protected Entity()
        {
            Validations = new List<ValidationError>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set ; }

        [NotMapped]
        public List<ValidationError> Validations { get; protected set; }

        public abstract bool IsValid();
    }
}
