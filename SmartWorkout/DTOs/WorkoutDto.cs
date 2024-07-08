using SmartWorkout.Entities;
using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.DTOs
{
    public class WorkoutDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please supply date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please supply date")]
        public string Username { get; set; }
    }
}

//public string Name { get; set; }

//public DateTime Date { get; set; }

//public int UserId { get; set; }

//public User User { get; set; }

//public ICollection<ExerciseLog> ExerciseLogs { get; set; }