using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author : Entity<Author>
    {   
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}
