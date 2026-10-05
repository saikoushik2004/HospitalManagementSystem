using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Library.Interfaces.Services;
using Microsoft.AspNetCore.Identity.Data;
using HospitalManagement.Library.Models;


namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService )
        {
            _userService = userService;
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userService.GetUserByUserNameAsync(request.Username);

            if (user == null)
            {
                return Unauthorized("Invalid Username or passoword");
            }

            if (user.PasswordHash != request.Password)
            {
                return Unauthorized("Invalid username and password");
            }

            return Ok(new
            {
                message = "Login Successful",
                userId = user.UserId,
                username = user.Username,
                fullName = user.FullName
            });
            
        }    
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }


}
