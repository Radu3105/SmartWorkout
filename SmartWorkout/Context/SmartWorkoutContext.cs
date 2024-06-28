using Microsoft.EntityFrameworkCore;
using SmartWorkout.Entities;

namespace SmartWorkout.Context
{
    public class SmartWorkoutContext : DbContext
    {
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<Workout> Workouts { get; set; }

        public DbSet<ExerciseLog> ExerciseLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(w => w.Workouts)
                .HasForeignKey(w => w.UserId)
                .HasConstraintName("FK_Workouts_User");

            modelBuilder.Entity<ExerciseLog>()
                .HasOne(el => el.Exercise)
                .WithMany(e => e.ExerciseLogs)
                .HasForeignKey(el => el.ExerciseId)
                .HasConstraintName("FK_ExerciseLogs_Exercises");

            modelBuilder.Entity<ExerciseLog>()
                .HasOne(el => el.Workout)
                .WithMany(w => w.ExerciseLogs)
                .HasForeignKey(el => el.WorkoutId)
                .HasConstraintName("FK_ExerciseLogs_Workouts");

            base.OnModelCreating(modelBuilder);
        }
    }
}
