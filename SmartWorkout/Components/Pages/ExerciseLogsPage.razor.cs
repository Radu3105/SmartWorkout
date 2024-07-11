using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SmartWorkout.Components.Services.Implementations;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Pages
{
    public partial class ExerciseLogsPage : ComponentBase
    {
        [Inject]
        public IExerciseLogRepository ExerciseLogRepository { get; set; }

        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        public ProtectedSessionStorage ProtectedSessionStorage { get; set; }

        [Parameter]
        public int? WorkoutId { get; set; }

        private ExerciseLog SelectedExerciseLog { get; set; }
        
        private ICollection<ExerciseLog> _exerciseLogs;

        private bool _isInitialized = false;

        private bool ShowConfirmDialog = false;

        //protected override async Task OnInitializedAsync()
        //{
        //    _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
        //    var currentUser = AuthorizationService.GetCurrentUser();
        //}

        protected override async Task OnParametersSetAsync()
        {
            if (WorkoutId != null)
            {
                _exerciseLogs = await ExerciseLogRepository.GetAllByWorkoutIdAsync(WorkoutId.Value);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !_isInitialized && WorkoutId == null)
            {
                var userResult = await ProtectedSessionStorage.GetAsync<UserDto>("UserSession");
                if (userResult.Success)
                {
                    var user = userResult.Value;
                    if (user != null)
                    {
                        if (user.IsTrainer)
                        {
                            _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
                        }
                        else
                        {
                            var workouts = await WorkoutRepository.GetAllByUserIdAsync(user.Id);
                            _exerciseLogs = new List<ExerciseLog>();
                            foreach (var workout in workouts)
                            {
                                foreach (var exerciseLog in await ExerciseLogRepository.GetAllByWorkoutIdAsync(workout.Id))
                                {
                                    _exerciseLogs.Add(exerciseLog);
                                }
                            }
                        }
                    }
                }
                _isInitialized = true;
                StateHasChanged();
            }
        }

        private async Task OnDeleteBtnClicked(DeleteCommandContext<ExerciseLog> context)
        {
            SelectedExerciseLog = context.Item;
            ShowConfirmDialog = true;
        }

        private async Task OnConfirmClose(bool confirmed)
        {
            ShowConfirmDialog = false;
            if (confirmed && SelectedExerciseLog != null)
            {
                if (SelectedExerciseLog != null)
                {
                    await ExerciseLogRepository.RemoveAsync(SelectedExerciseLog.Id);
                    if (WorkoutId == null)
                    {
                        _exerciseLogs = await ExerciseLogRepository.GetAllAsync();
                    }
                    else
                    {
                        _exerciseLogs = await ExerciseLogRepository.GetAllByWorkoutIdAsync(WorkoutId.Value);
                    }
                }
            }
            StateHasChanged();
        }

        //private async Task OnConfirmClose(bool confirmed)
        //{
        //    ShowConfirmDialog = false;

        //    if (confirmed && SelectedWorkout != null)
        //    {
        //        await WorkoutRepository.RemoveAsync(SelectedWorkout.Id);
        //        if (UserId == null)
        //        {
        //            _workouts = await WorkoutRepository.GetAllAsync();
        //        }
        //        else
        //        {
        //            _workouts = await WorkoutRepository.GetAllByUserIdAsync(UserId.Value);
        //        }
        //        StateHasChanged();
        //    }
        //}
    }
}
