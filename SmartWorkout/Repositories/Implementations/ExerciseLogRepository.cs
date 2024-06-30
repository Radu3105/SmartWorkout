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
    }
}
