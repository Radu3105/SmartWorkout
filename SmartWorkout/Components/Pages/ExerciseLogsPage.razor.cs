using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage : ComponentBase
    {
        [Inject]
        public IExerciseLogRepository ExerciseLogRepository { get; set; }

        private ICollection<ExerciseLog> _exerciseLogs;

        protected override async Task OnInitializedAsync()
        {
            _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
        }
    }
}
