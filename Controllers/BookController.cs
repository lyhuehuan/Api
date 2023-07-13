using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services.IServices;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("{id:int}")]
        public Book GetById(int id)
        {
            return _bookService.GetById(id);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            _bookService.Create(book);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Book book)
        {
            _bookService.Update(id, book);
            return StatusCode(201);
        }
    }
}
