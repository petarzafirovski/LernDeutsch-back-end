using LernDeutsch_Backend.Models.Identity;

namespace LernDeutsch_Backend.Services.Identity.SubUsers
{
    public interface ISubUserBaseService<T> where T : class
    {
        T? GetUser(string Id);
        List<T> GetAll();

        T? GetUserByUserName(string username);

        T CreateSubUser(BaseUser baseUser);
    }
}
