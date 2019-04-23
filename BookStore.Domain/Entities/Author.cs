using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
