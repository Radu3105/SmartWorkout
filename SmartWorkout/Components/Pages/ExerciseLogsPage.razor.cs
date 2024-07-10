using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using SmartWorkout.Components.Services.Implementations;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage : ComponentBase
    {
        [Inject]
        public IExerciseLogRepository ExerciseLogRepository { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [Parameter]
        public int WorkoutId { get; set; }

        private ExerciseLog SelectedExerciseLog { get; set; } 
        private ICollection<ExerciseLog> _exerciseLogs;
        private bool _isAdministrator = false;

        protected override async Task OnInitializedAsync()
        {
            _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
            var currentUser = AuthorizationService.GetCurrentUser();
            _isAdministrator = currentUser != null && currentUser.IsTrainer;
        }

        protected override async Task OnParametersSetAsync()
        {
            if (WorkoutId != 0)
            {
                _exerciseLogs = await ExerciseLogRepository.GetAllByWorkoutIdAsync(WorkoutId);
            }
        }

        private async Task OnDeleteBtnClicked(DeleteCommandContext<ExerciseLog> context)
        {
            SelectedExerciseLog = context.Item;
            if (SelectedExerciseLog != null)
            {
                await ExerciseLogRepository.RemoveAsync(SelectedExerciseLog.Id);
                await OnInitializedAsync();
            }
        }
    }
}
