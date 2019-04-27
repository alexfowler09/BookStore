using BookStore.Application.Interfaces;
using BookStore.Application.Notifications;
using BookStore.Application.ViewModels;
using BookStore.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/book")]
    public class BookController : BaseController
    {
        private readonly IBookAppService _bookAppService;        

        public BookController(IBookAppService bookAppService, IServiceNotificationHandler serviceNotificationHandler)
            : base (serviceNotificationHandler)
        {
            _bookAppService = bookAppService;            
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
                return ResponseBadRequest();

            return Ok(_bookAppService.GetById(newId.Value));
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]        
        public IActionResult Update([FromBody] BookViewModel book)
        {
            if (!_bookAppService.Update(book))
                return ResponseBadRequest();

            return Ok(_bookAppService.GetById(book.Id.Value));
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