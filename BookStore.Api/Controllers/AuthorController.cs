using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly IAuthorAppService _authorAppService;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public AuthorController(IAuthorAppService authorAppService, IDomainNotificationHandler domainNotificationHandler)
        {
            _authorAppService = authorAppService;
            _domainNotificationHandler = domainNotificationHandler;
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
        public IActionResult Add([FromBody] AuthorViewModel Author)
        {
            var newId = _authorAppService.Add(Author);

            if (newId == null)
                return BadRequest(_authorAppService.Validations);

            if (_domainNotificationHandler.HasNotifications())
                return BadRequest(_domainNotificationHandler.GetNotifications());

            return Ok(_authorAppService.GetById(newId.Value));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update([FromBody] AuthorViewModel Author)
        {
            if (!_authorAppService.Update(Author))
                return NotFound(Author);

            if (_domainNotificationHandler.HasNotifications())
                return BadRequest(_domainNotificationHandler.GetNotifications());

            return Ok(Author);
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