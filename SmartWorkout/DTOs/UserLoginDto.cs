using System.ComponentModel.DataAnnotations;

namespace SmartWorkout.DTOs
{
    public class UserLoginDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please supply email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please supply password")]
        public string Password { get; set; }
    }
}
