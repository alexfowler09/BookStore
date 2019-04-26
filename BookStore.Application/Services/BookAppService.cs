using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Application.Services
{    
    public class BookAppService : IBookAppService
    {
        private readonly IBookService _bookService;
        public List<ValidationError> Validations { get; private set; }

        public BookAppService(IBookService bookService)
        {
            _bookService = bookService;
            Validations = new List<ValidationError>();
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

        public bool Add(BookViewModel book)
        {
            var newBook = MapViewModelToEntity(book);

            if (!IsBusinessValid(newBook))
                return false;

            _bookService.Add(newBook);
            return true;
        }

        public BookViewModel GetById(Guid id)
        {
            var book = _bookService.GetBydId(id);            
            return MapEntityToViewModel(book);
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            var ret = new List<BookViewModel>();

            var books = _bookService.GetAll();
            foreach (var book in books)
                ret.Add(MapEntityToViewModel(book));

            return ret;
        }

        public bool Update(BookViewModel book)
        {
            var updatedBook = _bookService.GetBydId(book.Id.Value);

            if (updatedBook == null)
            {
                Validations.Add(new ValidationError("Book", "Registro não encontrado para o Id informado"));
                return false;
            }

            updatedBook.Title = book.Title;
            updatedBook.StockQty = book.StockQty;
            updatedBook.AuthorId = book.AuthorId;

            if (!IsBusinessValid(updatedBook))
                return false;

            _bookService.Update(updatedBook);

            return true;
        }

        private bool IsBusinessValid(Book book)
        {
            if (_bookService.TitleExists(book.Id, book.Title))            
                Validations.Add(new ValidationError("Book", "Já existe um livro cadastrado com o título informado"));

            return !Validations.Any();
        }

        public bool Remove(Guid id)
        {
            if (_bookService.GetBydId(id) == null)
                return false;

            _bookService.Remove(id);
            return true;            
        }

        private Book MapViewModelToEntity(BookViewModel book)
        {
            var ret = new Book();

            if (book != null)
            {
                ret.Id = book.Id.HasValue ? book.Id.Value : Guid.NewGuid();
                ret.Title = book.Title;
                ret.StockQty = book.StockQty;
                ret.AuthorId = book.AuthorId;
            }

            return ret;
        }

        private BookViewModel MapEntityToViewModel(Book book)
        {
            if (book == null)
                return null;
            else
            {
                var ret = new BookViewModel();
                
                ret.Id = book.Id;
                ret.Title = book.Title;
                ret.StockQty = book.StockQty;
                ret.AuthorId = book.AuthorId;

                ret.Author.Id = book.AuthorId;
                ret.Author.Name = book.Author.Name;                

                return ret;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _bookService.Dispose();
        }

        ~BookAppService()
        {
            Dispose(false);
        }
    }
}
