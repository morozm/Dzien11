using Microsoft.AspNetCore.Mvc;
using P06Shop.Shared;
using P06Shop.Shared.Services.BookService;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("getbooks")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            var result = await _bookService.GetBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost("postbook")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> PostBook()
        {
            var result = await _bookService.PostBookAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPut("putbook")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> PutBook()
        {
            var result = await _bookService.PutBookAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpDelete("deletebook")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> DeleteBook()
        {
            var result = await _bookService.DeleteBookAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }
    }
}
