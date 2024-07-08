using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class WorkoutRepository : BaseRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task<ICollection<Workout>> GetAllAsync()
        {
            return await context.Workouts.Include(x => x.User).ToListAsync();
        }

        public override async Task<Workout> GetByIdAsync(int id)
        {
            return await context.Workouts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<Workout>> GetAllByUserIdAsync(int userId)
        {
            return await context.Workouts.Where(x => x.UserId == userId).ToListAsync();
        }

        public void Detach(Workout entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        public Workout GetTrackedEntity(int id)
        {
            return context.Workouts.Local.FirstOrDefault(e => e.Id == id);
        }
    }
}
