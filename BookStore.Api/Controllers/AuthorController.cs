using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IEnumerable<AuthorViewModel> GetAll()
        {
            return _authorAppService.GetAll();
        }        
    }
}