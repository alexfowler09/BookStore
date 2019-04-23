using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IBookAppService
    {
        void Add(BookViewModel book);
        void Update(BookViewModel book);
        BookViewModel GetBydId(Guid id);
        IEnumerable<BookViewModel> GetAll();        
        void Remove(BookViewModel book);
        void Dispose();

        IEnumerable<BookViewModel> GetAllByTitleAscending();
        IEnumerable<BookViewModel> GetInStockByTitleAscending();

        string ValidateTitle(BookViewModel book);
        string ValidateNotNullRecord(Guid id);
    }
}
