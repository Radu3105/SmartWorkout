using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.DTOs
{
    public class ExerciseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please supply type")]
        public string Type { get; set; }
    }
}