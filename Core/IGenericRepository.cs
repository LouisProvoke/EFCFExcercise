namespace EFCFExcercise.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
