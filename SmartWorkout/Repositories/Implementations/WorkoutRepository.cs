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
    }
}
