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
        internal List<ValidationError> Validations { get; private set; }

        internal abstract bool IsValid();
    }
}
