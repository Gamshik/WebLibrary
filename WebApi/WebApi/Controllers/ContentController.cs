using Contracts;
using Entities.DTOs.BookDTOs;
using Entities.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Controller]
    [Route("api/{bookId}/[controller]")]
    public class ContentController : Controller
    {
        private readonly IBookService _bookService;
        public ContentController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        [Authorize]
        public IActionResult CrateTextOfBook(int bookId, [FromBody] string text)
        {
            var textOfBookCreate = new TextOfBookCreateDto { BookId = bookId, Text = text };
            var result = _bookService.CreateTextOfBook(textOfBookCreate);

            return StatusCode(result.StatusCode, result.Message);
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetTextOfBook(int bookId, [FromQuery] PagingParameters pagingParameters)
        {
            var text = _bookService.GetTextOfPage(bookId, pagingParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(text.MetaData));

            return Ok(text.ToString());
        }
    }
}
