using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage : ComponentBase
    {
        [Inject]
        public IExerciseLogRepository ExerciseLogRepository { get; set; }

        [Parameter]
        public int WorkoutId { get; set; }

        private ICollection<ExerciseLog> _exerciseLogs;

        protected override async Task OnInitializedAsync()
        {
            _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (WorkoutId != 0)
            {
                _exerciseLogs = await ExerciseLogRepository.GetAllByWorkoutIdAsync(WorkoutId);
            }
        }
    }
}
