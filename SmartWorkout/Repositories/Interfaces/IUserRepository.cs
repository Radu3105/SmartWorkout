using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartWorkout.Entities;

namespace SmartWorkout.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email);

        Task<User> GetByEmailAsync(string email);

        void Detach(User entity);

        User GetTrackedEntity(int id);
    }
}
