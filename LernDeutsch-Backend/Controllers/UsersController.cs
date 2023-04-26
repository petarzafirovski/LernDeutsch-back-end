using LernDeutsch_Backend.Models.Identity.DTO;
using LernDeutsch_Backend.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpGet("get-user-details")]
        public IActionResult GetUserDetails(string username)
        {
            var user =  userService.GetUser(username);
            if (user != null)
            {
                UserDTO userDto = new()
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return Ok(userDto);
            }
            else
                return NotFound("User not found");
        }

        [HttpPut("update-user-details")]
        public IActionResult UpdateUserDetails([FromBody] UserDTO userDTO)
        {
            try
            {
                userService.UpdateUser(userDTO);
                return Ok();
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
