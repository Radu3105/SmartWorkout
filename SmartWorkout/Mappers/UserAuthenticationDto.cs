using SmartWorkout.Entities;
using WorkoutApp.DTOs;

namespace SmartWorkout.Mappers
{
    public static class UserAuthenticationMapper
    {
        public static User ToUser(UserAuthenticationDto userAuthenticationDto)
        {
            return new User
            {
                Id = userAuthenticationDto.Id,
                FirstName = userAuthenticationDto.FirstName,
                LastName = userAuthenticationDto.LastName,
                Birthday = userAuthenticationDto.Birthday,
                Gender = userAuthenticationDto.Gender,
                Email = userAuthenticationDto.Email,
                isTrainer = userAuthenticationDto.isTrainer,
            };
        }

        public static UserAuthenticationDto ToUserAuthenticationDto(User user)
        {
            return new UserAuthenticationDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday,
                Gender = user.Gender,
                Email = user.Email,
                isTrainer = user.isTrainer,
            };
        }
    }
}
