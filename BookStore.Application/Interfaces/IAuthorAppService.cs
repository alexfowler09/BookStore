using BookStore.Application.ViewModels;
using BookStore.Domain;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorAppService : IDisposable
    {
        List<ValidationError> Validations { get; }

        Guid? Add(AuthorViewModel author);
        bool Update(AuthorViewModel author);
        AuthorViewModel GetById(Guid id);
        IEnumerable<AuthorViewModel> GetAll();
        bool Remove(Guid id);
    }
}
