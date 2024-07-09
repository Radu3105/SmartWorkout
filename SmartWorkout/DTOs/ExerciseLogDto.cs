using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.DTOs
{
    public class ExerciseLogDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply reps")]
        public int Reps { get; set; }

        [Required(ErrorMessage = "Please supply duration")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please supply exercise id")]
        public int ExerciseId { get; set; }

        [Required(ErrorMessage = "Please supply workout id")]
        public int WorkoutId { get; set; }
    }
}