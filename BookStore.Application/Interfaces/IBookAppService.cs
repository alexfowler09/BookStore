using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IBookAppService : IBaseAppService<BookViewModel, Book>
    {
        IEnumerable<BookViewModel> GetAllByTitleAscending();
        IEnumerable<BookViewModel> GetInStockByTitleAscending();
    }
}
