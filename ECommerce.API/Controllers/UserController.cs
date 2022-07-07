using ECommerce.API.Authorization;
using ECommerce.API.Services;
using ECommerce.SharedDataModels;
using ECommerce.SharedDataModels.Authenticate;
using ECommerce.SharedDataModels.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequestDTO model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [HttpGet("Admins")]
        [Authorize(UserRole.Administrator)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // Only admins can access other user records
            var currentUser = (UserDTO)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != UserRole.Administrator)
                return Unauthorized(new { message = "Unauthorized" });

            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}
