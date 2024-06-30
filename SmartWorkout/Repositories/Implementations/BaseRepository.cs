using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SmartWorkoutContext context;

        public BaseRepository(SmartWorkoutContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var addedEntity = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entityToRemove = await context.Set<T>().FindAsync(id);
            if (entityToRemove != null)
            {
                context.Set<T>().Remove(entityToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
