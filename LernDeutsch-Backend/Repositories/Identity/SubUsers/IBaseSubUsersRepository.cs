namespace LernDeutsch_Backend.Repositories.Identity.SubUsers
{
    public interface IBaseSubUsersRepository<T> where T : class
    {
        List<T> GetAll();
        T? Get(string Id);

        T? GetUserByUsername(string username);
    }
}
