using Microsoft.AspNetCore.Mvc;
using OneDemo.Mongo.Models;
using OneDemo.Mongo.Services;

namespace OneDemo.Mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(string id)
        {
            var book = _bookService.GetBook(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _bookService.CreateBook(book);

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut]
        public IActionResult UpdateBook(Book book)
        {
            _bookService.UpdateBook(book);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(string id)
        {
            var book = _bookService.GetBook(id);

            _bookService.RemoveBook(book);

            return Ok();
        }
    }
}