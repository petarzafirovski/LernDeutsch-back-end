namespace LernDeutsch_Backend.Repositories.Core
{
    public interface IBaseRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(Guid id);
        T Create(T entity);
        T Update(T entity);
        T Delete(Guid id);

    }
}
