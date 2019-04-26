using BookStore.Api.Extensions;
using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
using BookStore.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/book")]
    public class BookController : Controller
    {
        private readonly IBookAppService _bookAppService;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public BookController(IBookAppService bookAppService, IDomainNotificationHandler domainNotificationHandler)
        {
            _bookAppService = bookAppService;
            _domainNotificationHandler = domainNotificationHandler;
        }
        
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IEnumerable<BookViewModel> GetAll()
        {
            return _bookAppService.GetAllByTitleAscending();
        }

        [HttpGet]
        [Route("instock")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IEnumerable<BookViewModel> GetAllInStock()
        {
            return _bookAppService.GetInStockByTitleAscending();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(Guid id)
        {
            var ret = _bookAppService.GetById(id);
            if (ret == null)
                return NotFound();
            
            return Ok(ret);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Add([FromBody] BookViewModel book)
        {
            var newId = _bookAppService.Add(book);

            if (newId == null)            
                return BadRequest(_bookAppService.Validations);

            if (_domainNotificationHandler.HasNotifications())
                return BadRequest(_domainNotificationHandler.GetNotifications());

            return Ok(_bookAppService.GetById(newId.Value));
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update([FromBody] BookViewModel book)
        {
            if (!_bookAppService.Update(book))
                return NotFound(book);

            if (_domainNotificationHandler.HasNotifications())
                return BadRequest(_domainNotificationHandler.GetNotifications());

            return Ok(book);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Remove(Guid id)
        {
            if (!_bookAppService.Remove(id))
                return NotFound();

            return Ok();
        }
    }
}