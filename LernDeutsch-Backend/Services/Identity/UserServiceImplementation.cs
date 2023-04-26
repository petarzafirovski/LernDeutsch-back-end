using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Identity.DTO;
using LernDeutsch_Backend.Repositories.Identity;

namespace LernDeutsch_Backend.Services.Identity
{
    public class UserServiceImplementation : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserServiceImplementation(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void DeleteUser(string username)
        {
            userRepository.DeleteUser(username);
        }

        public BaseUser GetUser(string username)
        {
            return userRepository.GetUserByUsername(username);
        }

        public BaseUser GetUserById(string id)
        {
            return userRepository.GetUserById(id);
        }

        public List<BaseUser> GetUsers()
        {
            return userRepository.GetAllUsers();
        }

        public void UpdateUser(UserDTO userDTO)
        {
            userRepository.UpdateUser(userDTO);
        }
    }
}
