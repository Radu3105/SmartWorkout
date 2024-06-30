using Microsoft.Identity.Client;

namespace SmartWorkout.Entities
{
    public class Workout : BaseEntity
    {        
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        
        public int UserId { get; set; }
        
        public User User { get; set; }

        public ICollection<ExerciseLog> ExerciseLogs { get; set; }
    }
}
