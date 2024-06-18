using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.BookModels;

namespace Presentation.Controllers
{
    [Route("api/")]
    [ApiController]
    public class BookController(IBook book) : ControllerBase
    {
        private readonly Business.Interfaces.IBook _book = book;

        [Authorize]
        [HttpPost("addBook")]
        public async Task<IActionResult> AddBook(BookAddModel model)
        {
            try
            {
                var book = await _book.AddBook(model);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return Ok($"Unable to add book. {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("getBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _book.GetAllBook();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return Ok($"Unable to fetch books. {ex.Message}");
            }
        }
    }
}
