using BookStore.Application.Services;
using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Notifications;
using BookStore.Domain.Services;
using BookStore.Infra.Data.Context;
using BookStore.Infra.Data.Repositories;
using BookStore.Test.Mocks.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Test.AppServices
{
    public class BookAppServiceTest
    {
        protected BookStoreContext Db { get; }
        protected EFMockRepository MockRepository { get; }
        private BookRepository bookRepository { get; }
        private BookService bookService { get; }
        private BookAppService bookAppService { get; }
        private DomainNotificationHandler domainNotificationHandler { get; }

        public BookAppServiceTest()
        {
            Db = Utils.GetDbContext<BookStoreContext>();
            MockRepository = new EFMockRepository(Db);

            domainNotificationHandler = new DomainNotificationHandler();
            bookRepository = new BookRepository(Db);
            bookService = new BookService(bookRepository, domainNotificationHandler);
            bookAppService = new BookAppService(bookService);
        }

        [Fact]
        public void Book_GetAll()
        {
            var key1Author = Guid.NewGuid().ToString();
            var key2Author = Guid.NewGuid().ToString();

            var key1Book = Guid.NewGuid().ToString();
            var key2Book = Guid.NewGuid().ToString();

            var author1 = AuthorMock.Get(key1Author);
            var author2 = AuthorMock.Get(key2Author);

            MockRepository.Add(author1);
            MockRepository.Add(author2);

            var book1 = BookMock.GetWithStock(key1Book);
            book1.AuthorId = Guid.Parse(key1Author);

            var book2 = BookMock.GetWithStock(key2Book);
            book2.AuthorId = Guid.Parse(key2Author);

            MockRepository.Add(book1);
            MockRepository.Add(book2);

            List<BookViewModel> books = ServiceGetAllByTitleAscending();
            books.Should().HaveCount(2);
        }

        [Fact]
        public void Book_GetById()
        {
            var key1Author = Guid.NewGuid().ToString();
            var key2Author = Guid.NewGuid().ToString();

            var key1Book = Guid.NewGuid().ToString();
            var key2Book = Guid.NewGuid().ToString();

            var author1 = AuthorMock.Get(key1Author);
            var author2 = AuthorMock.Get(key2Author);

            MockRepository.Add(author1);
            MockRepository.Add(author2);

            var book1 = BookMock.GetWithStock(key1Book);
            book1.AuthorId = Guid.Parse(key1Author);

            var book2 = BookMock.GetWithStock(key2Book);
            book2.AuthorId = Guid.Parse(key2Author);

            MockRepository.Add(book1);
            MockRepository.Add(book2);

            BookViewModel book = ServiceGetById(Guid.Parse(key2Book));
            book.Id.Should().Be(Guid.Parse(key2Book));            
        }

        [Fact]
        public void Book_Update()
        {
            var key1Author = Guid.NewGuid().ToString();
            var key2Author = Guid.NewGuid().ToString();

            var key1Book = Guid.NewGuid().ToString();
            var key2Book = Guid.NewGuid().ToString();

            var author1 = AuthorMock.Get(key1Author);
            var author2 = AuthorMock.Get(key2Author);

            MockRepository.Add(author1);
            MockRepository.Add(author2);

            var book1 = BookMock.GetWithStock(key1Book);
            book1.AuthorId = Guid.Parse(key1Author);

            var book2 = BookMock.GetWithStock(key2Book);
            book2.AuthorId = Guid.Parse(key2Author);

            MockRepository.Add(book1);
            MockRepository.Add(book2);

            var bookViewModel = new BookViewModel();
            
            bookViewModel.Id = book2.Id;
            bookViewModel.Title = "testando";
            bookViewModel.StockQty = 55;

            // Utils.DetachAllEntities(Db);

            ServiceUpdate(bookViewModel);

            var entity = Db.Books.FirstOrDefault(x => x.Id == book2.Id);
            entity.Title.Should().Be(bookViewModel.Title);
            entity.StockQty.Should().Be(bookViewModel.StockQty);
        }

        private List<BookViewModel> ServiceGetAllByTitleAscending()
        {
            return bookAppService.GetAllByTitleAscending().ToList();
        }

        private BookViewModel ServiceGetById(Guid id)
        {
            return bookAppService.GetById(id);
        }

        private void ServiceUpdate(BookViewModel book)
        {
            bookAppService.Update(book);
        }

    }
}
