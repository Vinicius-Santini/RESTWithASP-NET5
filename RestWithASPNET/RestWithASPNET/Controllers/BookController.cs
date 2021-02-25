using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNET.Model;
using RestWithASPNET.Business;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
       

        private readonly ILogger<BookController> _logger;
        private IBookBusiness _booksBusiness;
        public BookController(ILogger<BookController> logger, IBookBusiness booksBusiness)
        {
            _logger = logger;
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _booksBusiness.FindById(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();

            return Ok(_booksBusiness.Create(book));
        }
        
        [HttpPut()]
        public IActionResult Put([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();

            return Ok(_booksBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);

            return NoContent();
        }

    }
}
