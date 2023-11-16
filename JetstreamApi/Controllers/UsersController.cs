﻿using JetstreamApi.DTO;
using JetstreamApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
        {
            if (!_userService.VerifyPassword(model.UserName, model.Password))
            {
                return Unauthorized("Invalid Credentials");
            }

            var token = _tokenService.CreateToken(model.UserName);
            return Ok(new JsonResult(new {
                Username = model.UserName,
                Token = token
            }));
           
        }

        [HttpPost("create")]
        //[Authorize()]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> create([FromBody] UserLoginDTO model)
        {
            _userService.CreateUser(model.UserName, model.Password);
            return Ok();
        }
    }
}
