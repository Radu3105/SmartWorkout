namespace SmartWorkout.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Birthday { get; set; }
        
        public string Gender { get; set; }

        public ICollection<Workout> Workouts { get; set; }
    }
}
