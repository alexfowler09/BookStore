using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Services
{    
    public class BookAppService : IBookAppService
    {
        private readonly IBookService _bookService;

        public BookAppService(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IEnumerable<BookViewModel> GetAllByTitleAscending()
        {
            var ret = new List<BookViewModel>();

            var books = _bookService.GetAllByTitleAscending();
            foreach (var book in books)
                ret.Add(MapEntityToViewModel(book));

            return ret;
        }

        public IEnumerable<BookViewModel> GetInStockByTitleAscending()
        {
            var ret = new List<BookViewModel>();

            var books = _bookService.GetInStockByTitleAscending();
            foreach (var book in books)
                ret.Add(MapEntityToViewModel(book));

            return ret;            
        }

        public string ValidateTitle(BookViewModel book)
        {
            return _bookService.ValidateTitle(MapViewModelToEntity(book));
        }

        public string ValidateNotNullRecord(Guid id)
        {
            return _bookService.ValidateNotNullRecord(id);
        }

        public void Add(BookViewModel book)
        {
            _bookService.Add(MapViewModelToEntity(book));     
        }

        public BookViewModel GetBydId(Guid id)
        {
            return MapEntityToViewModel(_bookService.GetBydId(id));
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            var ret = new List<BookViewModel>();

            var books = _bookService.GetAll();
            foreach (var book in books)
                ret.Add(MapEntityToViewModel(book));

            return ret;
        }

        public void Update(BookViewModel book)
        {
            _bookService.Update(MapViewModelToEntity(book));            
        }

        public void Remove(BookViewModel book)
        {
            _bookService.Remove(MapViewModelToEntity(book));            
        }

        public void Dispose()
        {
            _bookService.Dispose();
        }

        private Book MapViewModelToEntity(BookViewModel book)
        {
            var ret = new Book();

            if (book != null)
            {
                ret.Id = book.Id.Value;
                ret.Title = book.Title;
                ret.StockQty = book.StockQty;
                ret.AuthorId = book.AuthorId;
            }

            return ret;
        }

        private BookViewModel MapEntityToViewModel(Book book)
        {
            var ret = new BookViewModel();

            if (book != null)
            {
                ret.Id = book.Id;
                ret.Title = book.Title;
                ret.StockQty = book.StockQty;
                ret.AuthorId = book.AuthorId;

                ret.Author.Id = book.AuthorId;
                ret.Author.Name = book.Author.Name;
            }

            return ret;
        }        
    }
}
