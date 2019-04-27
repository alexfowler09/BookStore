using BookStore.Application.Interfaces;
using BookStore.Application.Notifications;
using BookStore.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/author")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorAppService _authorAppService;        

        public AuthorController(IAuthorAppService authorAppService, IServiceNotificationHandler serviceNotificationHandler)
            : base (serviceNotificationHandler)
        {
            _authorAppService = authorAppService;
            
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IEnumerable<AuthorViewModel> GetAll()
        {
            return _authorAppService.GetAll();
        }


        [HttpGet("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(Guid id)
        {
            var ret = _authorAppService.GetById(id);
            if (ret == null)
                return NotFound();

            return Ok(ret);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add([FromBody] AuthorViewModel author)
        {
            var newId = _authorAppService.Add(author);

            if (newId == null)
                return ResponseBadRequest();

            return Ok(_authorAppService.GetById(newId.Value));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update([FromBody] AuthorViewModel author)
        {
            if (!_authorAppService.Update(author))
                return ResponseBadRequest();

            return Ok(_authorAppService.GetById(author.Id.Value));
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Remove(Guid id)
        {
            if (!_authorAppService.Remove(id))
                return NotFound();

            return Ok();
        }

    }
}