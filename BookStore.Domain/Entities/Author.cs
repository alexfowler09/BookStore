﻿using BookStore.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Entities
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Book> Books { get; set; }
    }
}
