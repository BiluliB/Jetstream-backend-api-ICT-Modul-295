using JetstreamApi.DTO;
using JetstreamApi.Interfaces;
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

        /// <summary>
        /// Authenticate a user and return a JWT token
        /// </summary>
        /// <param name="userService">The user login Data containing the username and password</param>
        /// <param name="tokenService">A JSON result with the username and token</param>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
        {
            try
            {
                if (!_userService.VerifyPassword(model.UserName, model.Password))
                {
                    return Unauthorized("Invalid Credentials");
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var token = _tokenService.CreateToken(model.UserName);
            return Ok(new JsonResult(new {
                Username = model.UserName,
                Token = token
            }));
           
        }
        /// <summary>
        /// Creates a new user account with the given username and password
        /// </summary>
        /// <param name="model">The user login Data containing the username and password</param>
        /// <returns>A 200 OK if the user was created successfully</returns>
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginDTO))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> create([FromBody] UserLoginDTO model)
        {
            _userService.CreateUser(model.UserName, model.Password);
            return Ok();
        }
    }
}
