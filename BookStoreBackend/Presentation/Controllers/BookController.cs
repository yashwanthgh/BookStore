using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.BookModels;
using Model.ResponseModels;
using Repository.Entities;

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
                return Ok(new ResponseModel
                {
                    Success = book,
                    Message = "Book Added Successfully!"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Unable to add book. {ex.Message}"
                });
            }
        }

        [Authorize]
        [HttpGet("getBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _book.GetAllBook();
                return Ok(new ResponseModel<IEnumerable<Book>>
                {
                    Success = true,
                    Message = "Books Fetched Successfully",
                    Data = books
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel
                {
                    Success = false,
                    Message = $"Unable to fetch books. {ex.Message}"
                });
            }
        }
    }
}
