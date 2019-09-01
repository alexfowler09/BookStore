using BookStore.Application.Notifications;
using BookStore.Application.Services;
using BookStore.Application.ViewModels;
using BookStore.Domain.Notifications;
using BookStore.Domain.Services;
using BookStore.Infra.Data.Context;
using BookStore.Infra.Data.Repositories;
using BookStore.Test.Mocks.Entities;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Test.AppServices
{
    public class AuthorAppServiceTest
    {
        private BookStoreContext Db { get; }
        private EFMockRepository MockRepository { get; }
        private AuthorRepository authorRepository { get; }
        private AuthorService authorService { get; }
        private AuthorAppService authorAppService { get; }
        private DomainNotificationHandler domainNotificationHandler { get; }
        private ServiceNotificationHandler serviceNotificationHandler { get; }

        public AuthorAppServiceTest()
        {
            Db = Utils.GetDbContext<BookStoreContext>();
            MockRepository = new EFMockRepository(Db);

            domainNotificationHandler = new DomainNotificationHandler();
            serviceNotificationHandler = new ServiceNotificationHandler();
            authorRepository = new AuthorRepository(Db);
            authorService = new AuthorService(authorRepository, domainNotificationHandler);
            authorAppService = new AuthorAppService(authorService, domainNotificationHandler, serviceNotificationHandler);
        }

        [Fact]
        public void Author_GetAll()
        {
            string key1 = Guid.NewGuid().ToString();
            string key2 = Guid.NewGuid().ToString();

            var author1 = AuthorMock.Get(key1);
            var author2 = AuthorMock.Get(key2);

            MockRepository.Add(author1);
            MockRepository.Add(author2);

            List<AuthorViewModel> authors = ServiceGetAll();
            authors.Should().HaveCount(5);
        }

        private List<AuthorViewModel> ServiceGetAll()
        {            
            return authorAppService.GetAll().ToList();
        }
    }
}
