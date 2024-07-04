using System.ComponentModel.DataAnnotations;

namespace WorkoutApp.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please supply last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please supply birthday ")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Please supply gender")]
        public string Gender { get; set; }
    }
}