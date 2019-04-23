using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infra.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context) : base(context)
        {
            _context = context;
        }

        public override Book GetById(Guid id)
        {
            return _context.Books
                .AsNoTracking()
                .Include(a => a.Author)
                .FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAllByTitleAscending()
        {
            return _context.Books
                .Include(a => a.Author)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public IEnumerable<Book> GetInStockByTitleAscending()
        {            
            return _context.Books
                .Include(a => a.Author)
                .Where(b => b.StockQty > 0)
                .OrderBy(b => b.Title)
                .ToList();
        }
    }
}
