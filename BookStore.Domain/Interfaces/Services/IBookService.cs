using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Services
{
    public interface IBookService : IBaseService<Book>
    {
        IEnumerable<Book> GetAllByTitleAscending();
        IEnumerable<Book> GetInStockByTitleAscending();
        bool TitleExists(Guid id, string title);        
    }
}
