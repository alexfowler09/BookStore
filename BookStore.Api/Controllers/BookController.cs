using BookStore.Api.Extensions;
using BookStore.Application.Interfaces;
using BookStore.Application.ViewModels;
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

        public BookController(IBookAppService bookAppService)
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
            var ret = _bookAppService.GetBydId(id);
            if (ret == null)
                return NotFound();
            else            
                return Ok(ret);            
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Insert([FromBody] BookViewModel book)
        {
            List<string> validation = new List<string>();

            if (book != null && book.Id == null)
            {
                book.Id = Guid.NewGuid();
                validation.AddIfNotNull(_bookAppService.ValidateTitle(book));                
                if (validation.Count > 0)
                {
                    return BadRequest(new
                    {
                        errors = validation
                    });
                }

                _bookAppService.Add(book);

                return Ok(book);
            }

            return BadRequest();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Update([FromBody] BookViewModel book)
        {
            List<string> validation = new List<string>();

            if (book != null && book.Id != null)
            {
                validation.AddIfNotNull(_bookAppService.ValidateTitle(book));
                validation.AddIfNotNull(_bookAppService.ValidateNotNullRecord(book.Id.Value));
                if (validation.Count > 0)
                {
                    return BadRequest(new
                    {
                        errors = validation
                    });
                }

                _bookAppService.Update(book);

                return Ok(book);
            }

            return BadRequest();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            List<string> validation = new List<string>();

            validation.AddIfNotNull(_bookAppService.ValidateNotNullRecord(id));                

            if (validation.Count > 0)
            {
                return BadRequest(new
                {
                    errors = validation
                });
            }

            _bookAppService.Remove(_bookAppService.GetBydId(id));

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}