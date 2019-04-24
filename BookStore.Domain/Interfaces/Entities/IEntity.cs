using System;

namespace BookStore.Domain.Interfaces.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
