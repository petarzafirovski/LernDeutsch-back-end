using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Identity.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace LernDeutsch_Backend.Services.Identity
{
    public interface IUserService
    {
        BaseUser GetUser(string username);
        List<BaseUser> GetUsers();
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(string username);
    }
}
