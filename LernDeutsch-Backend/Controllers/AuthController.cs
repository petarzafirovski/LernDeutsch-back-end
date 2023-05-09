using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Identity.DTO;
using LernDeutsch_Backend.Services.Identity.SubUsers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        private readonly ITutorService _tutorService;

        public AuthController(
            UserManager<BaseUser> baseUser,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IHttpContextAccessor contextAccessor,
            IStudentService studentService,
            ITutorService tutorService)
        {
            _userManager = baseUser;
            _roleManager = roleManager;
            _configuration = configuration;
            _studentService = studentService;
            _tutorService = tutorService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                user.UserName
            });
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var user = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (user != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO { Status = "Error", Message = "User did not log out successfully" });
            }
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO { Status = "Error", Message = "User already exists" });

            BaseUser user = new()
            {
                Email = registerDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                StringBuilder stringBuilderErrorMessages = new();
                foreach (var errorMessage in result.Errors)
                {
                    stringBuilderErrorMessages.AppendLine(errorMessage.Code + ", Message:" + errorMessage.Description);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO { Status = "Error", Message = stringBuilderErrorMessages.ToString() });
            }
            else
            {
                if (registerDto.Role.Equals(UserRoles.Tutor))
                {
                    user.Tutor = _tutorService.CreateSubUser(user);
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    user.Student = _studentService.CreateSubUser(user);
                    await _userManager.UpdateAsync(user);
                }               
            }

            bool doesRoleExist = _roleManager.Roles.Any(role => role.Name.Equals(registerDto.Role));

            if (!doesRoleExist)
            {
                switch (registerDto.Role)
                {
                    case UserRoles.Student:
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                        await _userManager.AddToRoleAsync(user, UserRoles.Student);
                        break;
                    case UserRoles.Tutor:
                        await _roleManager.CreateAsync(new IdentityRole(UserRoles.Tutor));
                        await _userManager.AddToRoleAsync(user, UserRoles.Tutor);
                        break;
                    default:
                        return StatusCode(StatusCodes.Status400BadRequest, new ResponseDTO { Status = "Error", Message = "The provided role does not exist within the system." });
                }
            }

            return Ok(new ResponseDTO { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
