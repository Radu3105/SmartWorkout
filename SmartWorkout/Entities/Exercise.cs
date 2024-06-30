namespace SmartWorkout.Entities
{
    public class Exercise : BaseEntity
    {        
        public string Description { get; set; }
        
        public string Type { get; set; }

        public ICollection<ExerciseLog> ExerciseLogs { get; set; }
    }
}
