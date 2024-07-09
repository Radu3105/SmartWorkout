using SmartWorkout.Entities;
using WorkoutApp.DTOs;

namespace SmartWorkout.Mappers
{
    public static class ExerciseLogMapper
    {
        public static ExerciseLogDto ToExerciseLogDto(ExerciseLog exerciseLog)
        {
            return new ExerciseLogDto
            {
                Id = exerciseLog.Id,
                ExerciseId = exerciseLog.ExerciseId,
                WorkoutId = exerciseLog.WorkoutId,
                Reps = exerciseLog.Reps,
                Duration = exerciseLog.Duration,
            };
        }

        public static ExerciseLog ToExerciseLog(ExerciseLogDto exerciseLogDto)
        {
            return new ExerciseLog
            {
                Id = exerciseLogDto.Id,
                ExerciseId = exerciseLogDto.ExerciseId,
                WorkoutId = exerciseLogDto.WorkoutId,
                Reps = exerciseLogDto.Reps,
                Duration = exerciseLogDto.Duration,
            };
        }
    }
}
