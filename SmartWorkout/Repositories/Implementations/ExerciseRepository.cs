using Microsoft.EntityFrameworkCore;
using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(SmartWorkoutContext context) : base(context)
        {
        }

        public override async Task<Exercise> GetByIdAsync(int id)
        {
            return await context.Exercises.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Detach(Exercise entity)
        {
            context.Entry(entity).State = EntityState.Detached;
        }

        public Exercise GetTrackedEntity(int id)
        {
            return context.Exercises.Local.FirstOrDefault(e => e.Id == id);
        }
    }
}
