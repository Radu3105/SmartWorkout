namespace SmartWorkout.Entities
{
    public class ExerciseLog : BaseEntity
    {        
        public int Reps { get; set; }
        
        public int Duration { get; set; }

        public int ExerciseId {  get; set; }

        public Exercise Exercise { get; set; }

        public int WorkoutId { get; set; }
        
        public Workout Workout { get; set; }
    }
}
