using SmartWorkout.Entities;
using WorkoutApp.DTOs;

namespace SmartWorkout.Mappers
{
    public static class ExerciseMapper
    {
        public static Exercise ToExercise(ExerciseDto exerciseDto)
        {
            return new Exercise
            {
                Id = exerciseDto.Id,
                Description = exerciseDto.Description,
                Type = exerciseDto.Type,
            };
        }

        public static ExerciseDto ToExerciseDto(Exercise user)
        {
            return new ExerciseDto
            {
                Id = user.Id,
                Description = user.Description,
                Type = user.Type,
            };
        }
    }
}
