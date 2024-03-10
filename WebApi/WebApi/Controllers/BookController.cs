using Domain.Classes.DTOs.BookDTOs;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        [Authorize]
        public IActionResult CrateBookPreview([FromBody] BookPreviewCreateDto bookPreviewCreateDto)
        {
            var result = _bookService.CreateBookPreview(bookPreviewCreateDto);

            return StatusCode(result.StatusCode, result.Message);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAllBookPreviews();

            return Ok(books);
        }
    }
}
