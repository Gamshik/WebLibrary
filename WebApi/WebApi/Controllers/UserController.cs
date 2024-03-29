﻿using Contracts;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggerService _loggerService;
        public UserController(IUserService userService, ILoggerService loggerService)
        {
            _userService = userService;
            _loggerService = loggerService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody] UserRegistrationDto user, CancellationToken cancellationToken = default)
        {
            var result = await _userService.RegistrationAsync(user, cancellationToken);

            return StatusCode(result.StatusCode, new { Message = result.Message });
        }
        [HttpPost("Authorize")]
        public async Task<IActionResult> AuthorizeAsync([FromBody] UserAuthorizeDto user, CancellationToken cancellationToken = default)
        {
            var jwtToken = await _userService.AuthorizationAsync(user, cancellationToken);

            if (jwtToken == null)
                return Unauthorized(new { Message = "Entered invalid data!" });

            return Ok(jwtToken);
        }
    }
}
