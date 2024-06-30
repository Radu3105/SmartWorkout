using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        
        Task<T> GetByIdAsync(int id);
        
        Task<T> AddAsync(T entity);
        
        Task RemoveAsync(int id);
        
        Task UpdateAsync(T entity);
    }
}
