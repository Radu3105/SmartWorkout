using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class ExerciseLogRepository : BaseRepository<ExerciseLog>, IExerciseLogRepository
    {
        public ExerciseLogRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task<ICollection<ExerciseLog>> GetAllAsync()
        {
            return await context.ExerciseLogs.Include(x => x.Workout).Include(x => x.Exercise).ToListAsync();
        }

        public async Task<ICollection<ExerciseLog>> GetAllByWorkoutIdAsync(int workoutId)
        {
            return await context.ExerciseLogs.Where(x => x.WorkoutId == workoutId).ToListAsync();
        }
    }
}
