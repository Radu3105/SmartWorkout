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

        public static ExerciseDto ToExerciseDto(Exercise exercise)
        {
            return new ExerciseDto
            {
                Id = exercise.Id,
                Description = exercise.Description,
                Type = exercise.Type,
            };
        }
    }
}
