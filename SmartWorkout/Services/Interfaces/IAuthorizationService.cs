using SmartWorkout.DTOs;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Services.Interfaces
{
    public interface IAuthorizationService
    {
        public Task Login(UserLoginDto loginDto);

        public UserDto GetCurrentUser();

        bool IsUserPresent();

        void LogOut();
    }
}