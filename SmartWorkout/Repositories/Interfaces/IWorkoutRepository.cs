using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IWorkoutRepository : IBaseRepository<Workout>
    {
        Task<ICollection<Workout>> GetAllByUserIdAsync(int userId);

        Task<User> GetUserByWorkoutIdAsync(int workoutId);

        void Detach(Workout entity);

        Workout GetTrackedEntity(int id);
    }
}
