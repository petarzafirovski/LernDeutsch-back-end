using LernDeutsch_Backend.Data;
using LernDeutsch_Backend.Models.Identity;
using LernDeutsch_Backend.Models.Identity.DTO;
using Microsoft.AspNetCore.Identity;

namespace LernDeutsch_Backend.Repositories.Identity
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepositoryImplementation(UserManager<BaseUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this._roleManager = roleManager;
        }

        public void AddUser(RegisterDTO registerDTO)
        {
            var user = GetUserTypeBasedOnRole(registerDTO.Role);
            user.Email = registerDTO.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.UserName = registerDTO.UserName;
            user.FirstName = registerDTO.FirstName;
            user.LastName = registerDTO.LastName;

            userManager.CreateAsync(user).Wait();

            AssignRoleToUser(registerDTO, user);
        }

        private void AssignRoleToUser(RegisterDTO registerDTO, BaseUser user)
        {
            bool doesRoleExist = _roleManager.Roles.Any(role => role.Name.Equals(registerDTO.Role));
            if (!doesRoleExist)
            {
                switch (registerDTO.Role)
                {
                    case UserRoles.Student:
                        _roleManager.CreateAsync(new IdentityRole(UserRoles.Student)).Wait();
                        break;
                    case UserRoles.Tutor:
                        _roleManager.CreateAsync(new IdentityRole(UserRoles.Tutor)).Wait();
                        break;
                }
            }
            userManager.AddToRoleAsync(user, registerDTO.Role).Wait();
        }

        private BaseUser GetUserTypeBasedOnRole(string role)
        {
            return role switch
            {
                UserRoles.Student => new Student(),
                UserRoles.Tutor => new Tutor(),
                _ => new Student(),
            };
        }

        public void DeleteUser(string username)
        {
            var user = GetUserByUsername(username);
            if (user != null)
                userManager.DeleteAsync(user).Wait();
        }

        public BaseUser GetUserByUsername(string username)
        {
            var user = userManager.FindByNameAsync(username);
            return user.Result;
        }

        public BaseUser GetUserById(string id)
        {
            var user = userManager.FindByIdAsync(id);
            return user.Result;
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = userManager.FindByIdAsync(userDTO.Id).Result;
            if (user != null)
            {
                user.UserName = userDTO.UserName ?? user.UserName;
                user.FirstName = userDTO.FirstName ?? user.UserName;
                user.LastName = userDTO.LastName ?? user.UserName;
                userManager.UpdateAsync(user).Wait();
            }
        }

        public List<BaseUser> GetAllUsers()
        {
            return userManager.Users.ToList();
        }
    }
}
