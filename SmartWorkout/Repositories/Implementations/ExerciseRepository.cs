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
    }
}
