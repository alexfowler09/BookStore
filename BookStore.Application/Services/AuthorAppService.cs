using BookStore.Application.Interfaces;
using BookStore.Application.Notifications;
using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Domain.Notifications;
using System;

namespace BookStore.Application.Services
{
    public class AuthorAppService : BaseAppService<AuthorViewModel, Author>, IAuthorAppService
    {
        private readonly IAuthorService _authorService;

        public AuthorAppService(IAuthorService authorService, 
            IDomainNotificationHandler domainNotificationHandler,
            IServiceNotificationHandler serviceNotificationHandler) 
            : base(authorService, domainNotificationHandler, serviceNotificationHandler)
        {
            _authorService = authorService;
        }

        protected override void BusinessValidation(Author entity)
        {
            
        }

        protected override AuthorViewModel MapEntityToViewModel(Author entity)
        {
            var ret = new AuthorViewModel();

            if (entity != null)
            {
                ret.Id = entity.Id;
                ret.Name = entity.Name;
            }

            return ret;
        }

        protected override Author MapViewModelToEntity(AuthorViewModel viewModel)
        {
            var ret = new Author();

            if (viewModel != null)
            {
                ret.Id = viewModel.Id.HasValue ? viewModel.Id.Value : Guid.NewGuid();
                ret.Name = viewModel.Name;
            }

            return ret;
        }

        protected override bool UpdateRecord(AuthorViewModel viewModel)
        {
            var updatedAuthor = _authorService.GetById(viewModel.Id.Value);

            if (updatedAuthor == null)
            {
                NotifyRecordNotFound(typeof(Author).Name, "Registro não encontrado para o Id informado");
                return false;
            }

            updatedAuthor.Name = viewModel.Name;

            return ProcessUpdate(updatedAuthor);
        }
    }
}
