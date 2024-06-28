using SmartWorkout.Context;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly SmartWorkoutContext _context;

        public UserRepository(SmartWorkoutContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
    }
}
