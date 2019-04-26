using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace BookStore.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorService _authorService;
        public List<ValidationError> Validations { get; private set; }

        public AuthorAppService(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public bool Add(AuthorViewModel author)
        {
            var newAuthor = MapViewModelToEntity(author);

            _authorService.Add(newAuthor);
            return true;
        }

        public bool Update(AuthorViewModel author)
        {
            var updatedAuthor = _authorService.GetBydId(author.Id.Value);

            if (updatedAuthor == null)
            {
                Validations.Add(new ValidationError("Author", "Registro não encontrado para o Id informado"));
                return false;
            }

            updatedAuthor.Name = author.Name;
            _authorService.Update(updatedAuthor);

            return true;
        }

        public AuthorViewModel GetById(Guid id)
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

        public bool Remove(Guid id)
        {
            if (_authorService.GetBydId(id) == null)
                return false;

            _authorService.Remove(id);
            return true;            
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
                ret.Id = author.Id.HasValue ? author.Id.Value : Guid.NewGuid();                
                ret.Name = author.Name;
            }

            return ret;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _authorService.Dispose();
        }

        ~AuthorAppService()
        {
            Dispose(false);
        }
    }
}
