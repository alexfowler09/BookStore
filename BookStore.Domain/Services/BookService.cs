using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Repositories;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) :
            base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string ValidateNotNullRecord(Guid id)
        {
            if (_bookRepository.GetById(id) == null)
                return "Não existe registro para o Id informado";

            return null;
        }

        public string ValidateTitle(Book book)
        {   
            if (_bookRepository.GetAll().Where(x => x.Title == book.Title && x.Id != book.Id).Count() > 0)
                return "Já existe um outro livro com este título";

            return null;
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
