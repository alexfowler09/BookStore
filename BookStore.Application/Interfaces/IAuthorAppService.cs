using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorAppService : IBaseAppService<AuthorViewModel, Author>
    {
    }
}
