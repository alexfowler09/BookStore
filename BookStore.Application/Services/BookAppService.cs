using BookStore.Application.Interfaces;
using BookStore.Application.Notifications;
using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class BookAppService : BaseAppService<BookViewModel, Book>, IBookAppService
    {
        private readonly IBookService _bookService;
        private readonly IServiceNotificationHandler _serviceNotificationHandler;

        public BookAppService(IBookService bookService, 
            IDomainNotificationHandler domainNotificationHandler,
            IServiceNotificationHandler serviceNotificationHandler) 
            : base(bookService, domainNotificationHandler, serviceNotificationHandler)
        {
            _bookService = bookService;
            _serviceNotificationHandler = serviceNotificationHandler;
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

        protected override bool UpdateRecord(BookViewModel viewModel)
        {
            var updatedBook = _bookService.GetById(viewModel.Id.Value);            

            if (updatedBook == null)
            {
                NotifyRecordNotFound(typeof(Book).Name, "Registro não encontrado para o Id informado");
                return false;
            }

            updatedBook.Title = viewModel.Title;
            updatedBook.StockQty = viewModel.StockQty;
            updatedBook.AuthorId = viewModel.AuthorId;

            return ProcessUpdate(updatedBook);
        }

        protected override void BusinessValidation(Book entity)
        {
            if (_bookService.TitleExists(entity.Id, entity.Title))
                _serviceNotificationHandler.Add(new ServiceNotification("Book", "Já existe um livro cadastrado com o título informado"));            
        }

        protected override BookViewModel MapEntityToViewModel(Book entity)
        {
            if (entity == null)
                return null;
            else
            {
                var ret = new BookViewModel();

                ret.Id = entity.Id;
                ret.Title = entity.Title;
                ret.StockQty = entity.StockQty;
                ret.AuthorId = entity.AuthorId;

                ret.Author.Id = entity.AuthorId;
                ret.Author.Name = entity.Author.Name;

                return ret;
            }
        }

        protected override Book MapViewModelToEntity(BookViewModel viewModel)
        {
            var ret = new Book();

            if (viewModel != null)
            {
                ret.Id = viewModel.Id.HasValue ? viewModel.Id.Value : Guid.NewGuid();
                ret.Title = viewModel.Title;
                ret.StockQty = viewModel.StockQty;
                ret.AuthorId = viewModel.AuthorId;
            }

            return ret;
        }        
    }
}
