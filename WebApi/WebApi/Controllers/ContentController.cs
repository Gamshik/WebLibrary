﻿using Domain.Classes.DTOs.BookDTOs;
using Domain.Classes.Parameters;
using Domain.Interfaces;
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
        [HttpPost("CreateTextOfBook")]
        public IActionResult CrateTextOfBook(int bookId, [FromBody] string text)
        {
            var textOfBookCreate = new TextOfBookCreateDto { BookId = bookId, Text = text };
            var result = _bookService.CreateTextOfBook(textOfBookCreate);

            return StatusCode(result.StatusCode, result.Message);
        }
        [HttpGet("TextOfBook")]
        public IActionResult GetTextOfBook(int bookId, [FromQuery] PagingParameters pagingParameters)
        {
            var text = _bookService.GetTextOfPage(bookId, pagingParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(text.MetaData));

            return Ok(text.ToString());
        }
    }
}