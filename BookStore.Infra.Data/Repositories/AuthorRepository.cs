using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Infra.Data.Context;

namespace BookStore.Infra.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        private readonly BookStoreContext _context;

        public AuthorRepository(BookStoreContext context) : base(context)
        {
            _context = context;
        }
    }
}
