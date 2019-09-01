using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;

namespace BookStore.Domain.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {   
        public AuthorService(IAuthorRepository authorRepository, IDomainNotificationHandler domainNotificationHandler) :
            base(authorRepository, domainNotificationHandler)
        {
        } 
    }
}
