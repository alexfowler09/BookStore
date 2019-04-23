using BookStore.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Interfaces
{
    public interface IAuthorAppService
    {
        void Add(AuthorViewModel book);
        void Update(AuthorViewModel book);
        AuthorViewModel GetBydId(Guid id);
        IEnumerable<AuthorViewModel> GetAll();        
        void Remove(AuthorViewModel book);
        void Dispose();
    }
}
