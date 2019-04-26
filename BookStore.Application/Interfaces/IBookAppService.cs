using BookStore.Application.ViewModels;
using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IBookAppService: IDisposable
    {
        List<ValidationError> Validations { get; }

        Guid? Add(BookViewModel book);
        bool Update(BookViewModel book);
        BookViewModel GetById(Guid id);
        IEnumerable<BookViewModel> GetAll();        
        bool Remove(Guid id);

        IEnumerable<BookViewModel> GetAllByTitleAscending();
        IEnumerable<BookViewModel> GetInStockByTitleAscending();
    }
}
