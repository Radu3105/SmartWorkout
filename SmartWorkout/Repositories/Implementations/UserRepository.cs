using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Detach(User entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        public User GetTrackedEntity(int id)
        {
            return context.Users.Local.FirstOrDefault(e => e.Id == id);
        }
    }
}
