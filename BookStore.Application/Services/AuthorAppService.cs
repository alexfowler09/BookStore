using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorService _authorService;

        public AuthorAppService(IAuthorService authorService)            
        {
            _authorService = authorService;
        }

        public void Add(AuthorViewModel author)
        {
            _authorService.Add(MapViewModelToEntity(author));
        }

        public void Update(AuthorViewModel author)
        {
            _authorService.Update(MapViewModelToEntity(author));
        }

        public AuthorViewModel GetBydId(Guid id)
        {
            return MapEntityToViewModel(_authorService.GetBydId(id));
        }

        public IEnumerable<AuthorViewModel> GetAll()
        {
            var ret = new List<AuthorViewModel>();

            var authors = _authorService.GetAll();
            foreach (var author in authors)
                ret.Add(MapEntityToViewModel(author));

            return ret;            
        }

        public void Remove(AuthorViewModel author)
        {
            _authorService.Remove(MapViewModelToEntity(author));
        }

        public void Dispose()
        {
            _authorService.Dispose();
        }

        private AuthorViewModel MapEntityToViewModel(Author author)
        {
            var ret = new AuthorViewModel();

            if (author != null)
            {
                ret.Id = author.Id;
                ret.Name = author.Name;
            }

            return ret;
        }

        private Author MapViewModelToEntity(AuthorViewModel author)
        {
            var ret = new Author();

            if (author != null)
            {
                ret.Id = author.Id.Value;
                ret.Name = author.Name;
            }

            return ret;
        }
    }
}
