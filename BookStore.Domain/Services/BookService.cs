using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IDomainNotificationHandler domainNotificationHandler) :
            base(bookRepository, domainNotificationHandler)
        {
            _bookRepository = bookRepository;
        }

        public bool ValidateTitle(Guid id, string title)
        {   
            return _bookRepository.GetAll().Any(x => x.Title == title && x.Id != id);
        }

        public IEnumerable<Book> GetAllByTitleAscending()
        {
            return _bookRepository.GetAllByTitleAscending();
        }

        public IEnumerable<Book> GetInStockByTitleAscending()
        {
            return _bookRepository.GetInStockByTitleAscending();
        }        
    }
}
