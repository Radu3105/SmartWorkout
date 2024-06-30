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
    }
}
