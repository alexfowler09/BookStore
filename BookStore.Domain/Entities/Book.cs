using BookStore.Domain.Interfaces.Entities;
using System;

namespace BookStore.Domain.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int StockQty { get; set; }
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
