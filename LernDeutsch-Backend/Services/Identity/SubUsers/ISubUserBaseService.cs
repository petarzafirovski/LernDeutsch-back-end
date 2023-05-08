namespace LernDeutsch_Backend.Services.Identity.SubUsers
{
    public interface ISubUserBaseService<T> where T : class
    {
        T? GetUser(string Id);
        List<T> GetAll();

        T? GetUserByUserName(string username);
    }
}
