using Microsoft.EntityFrameworkCore;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        void Detach(User entity);

        User GetTrackedEntity(int id);
    }
}
