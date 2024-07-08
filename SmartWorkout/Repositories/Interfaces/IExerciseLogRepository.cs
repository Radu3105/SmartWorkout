using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseLogRepository : IBaseRepository<ExerciseLog>
    {
        Task<ICollection<ExerciseLog>> GetAllByWorkoutIdAsync(int workoutId);
    }
}
