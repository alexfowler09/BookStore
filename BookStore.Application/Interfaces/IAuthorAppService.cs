using BookStore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorAppService
    {
        void Add(AuthorViewModel author);
        void Update(AuthorViewModel author);
        AuthorViewModel GetBydId(Guid id);
        IEnumerable<AuthorViewModel> GetAll();        
        void Remove(AuthorViewModel author);
        void Dispose();
    }
}
