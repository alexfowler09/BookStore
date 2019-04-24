using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Infra.Data.Context;

namespace BookStore.Infra.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookStoreContext context) : base(context)
        {            
        }
    }
}
