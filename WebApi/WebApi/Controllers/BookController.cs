using Domain.Classes.DTOs.BookDTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost("CreateBookPreview")]
        public IActionResult CrateBookPreview([FromBody] BookPreviewCreateDto bookPreviewCreateDto)
        {
            var result = _bookService.CreateBookPreview(bookPreviewCreateDto);

            return StatusCode(result.StatusCode, result.Message);
        }
        [HttpGet("BooksPreviews")]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAllBookPreviews();

            return Ok(books);
        }
    }
}
