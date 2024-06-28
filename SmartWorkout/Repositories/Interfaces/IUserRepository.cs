using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
    }
}
