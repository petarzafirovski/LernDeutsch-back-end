using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Identity.DTO;

namespace LernDeutsch_Backend.Repositories.Identity
{
    public interface IUserRepository 
    {
        BaseUser GetUserByUsername(string username);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(string username);
        List<BaseUser> GetAllUsers();
    }
}
