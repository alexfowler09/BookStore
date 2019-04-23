using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Api.Controllers
{
    [Route("author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [HttpGet]
        public IEnumerable<AuthorViewModel> GetAll()
        {
            return _authorAppService.GetAll();
        }        
    }
}