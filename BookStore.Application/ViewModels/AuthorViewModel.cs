using BookStore.Application.ViewModels.Interfaces;
using System;

namespace BookStore.Application.ViewModels
{
    public class AuthorViewModel : IBaseViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
