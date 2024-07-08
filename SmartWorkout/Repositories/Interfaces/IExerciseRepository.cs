using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IExerciseRepository : IBaseRepository<Exercise>
    {
        void Detach(Exercise entity);

        Exercise GetTrackedEntity(int id);
    }
}
