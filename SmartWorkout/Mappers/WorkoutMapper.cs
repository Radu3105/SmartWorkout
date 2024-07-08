using SmartWorkout.Entities;
using WorkoutApp.DTOs;

namespace SmartWorkout.Mappers
{
    public static class WorkoutMapper
    {
        public static Workout ToWorkout(WorkoutDto workoutDto)
        {
            return new Workout
            {
                Id = workoutDto.Id,
                Name = workoutDto.Name,
                Date = workoutDto.Date,
            };
        }

        public static WorkoutDto ToWorkoutDto(Workout workout)
        {
            return new WorkoutDto
            {
                Id = workout.Id,
                Name = workout.Name,
                Date = workout.Date,
            };
        }
    }
}
