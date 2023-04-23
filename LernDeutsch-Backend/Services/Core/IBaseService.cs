namespace LernDeutsch_Backend.Services.Core
{
    public interface IBaseService<T> where T : class
    {
        T Create(T entity);
        T Update(Guid id, T entity);
        T Delete(Guid id);
        T? GetById(Guid id);
        List<T> GetAll();
    }
}
