namespace Onion.Application.Interfaces
{
   public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsycn();

        Task<T> GetByIdAsycn(Guid id);

        Task CreateAsycn(T entity);
        void Update(T entity);
        Task DeleteAsycn(Guid id);
    }
}
