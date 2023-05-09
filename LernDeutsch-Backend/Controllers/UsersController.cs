using LernDeutsch_Backend.Models.Identity.DTO;
using LernDeutsch_Backend.Services.Identity;
using LernDeutsch_Backend.Services.Identity.SubUsers;
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
        private readonly ITutorService tutorService;

        public UsersController(IUserService userService, ITutorService tutorService)
        {
            this.userService = userService;
            this.tutorService = tutorService;
        }

        [HttpGet("get-tutors")]
        public IActionResult GetTutors()
        {
            return Ok(tutorService.GetAll());
        }


        [HttpGet("get-user-details")]
        public IActionResult GetUserDetails([FromQuery(Name = "username")] string username)
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
