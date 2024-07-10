using SmartWorkout.Entities;
using WorkoutApp.DTOs;

namespace SmartWorkout.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Birthday = userDto.Birthday,
                Gender = userDto.Gender,
                Email = userDto.Email,
                isTrainer = userDto.IsTrainer,
            };
        }

        public static UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Birthday = user.Birthday,
                Gender = user.Gender,
                Email = user.Email,
                IsTrainer = user.isTrainer,
            };
        }
    }
}
