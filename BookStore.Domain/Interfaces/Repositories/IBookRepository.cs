using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllByTitleAscending();
        IEnumerable<Book> GetInStockByTitleAscending();
    }
}
