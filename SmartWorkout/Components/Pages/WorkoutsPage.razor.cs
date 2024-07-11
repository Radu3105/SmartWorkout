using Blazorise.DataGrid;
using BlazorServerAuthenticationAndAuthorization.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;
using System.Collections.Generic;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Pages
{
    public partial class WorkoutsPage : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private ProtectedSessionStorage ProtectedSessionStorage { get; set; }

        [Parameter]
        public int? UserId { get; set; }

        private ICollection<Workout> _workouts;
        public Workout SelectedWorkout { get; set; }
        private bool _isInitialized = false;
        private bool ShowConfirmDialog { get; set; }


        //protected override async Task OnInitializedAsync()
        //{
        //    _workouts = await WorkoutRepository.GetAllAsync();
        //}

        protected override async Task OnParametersSetAsync()
        {
            if (UserId != null)
            {
                _workouts = await WorkoutRepository.GetAllByUserIdAsync((int)UserId);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && !_isInitialized && UserId == null)
            {
                var userResult = await ProtectedSessionStorage.GetAsync<UserDto>("UserSession");
                if (userResult.Success)
                {
                    var user = userResult.Value;
                    if (user != null)
                    {
                        if (user.IsTrainer)
                        {
                            _workouts = await WorkoutRepository.GetAllAsync();
                        }
                        else
                        {
                            _workouts = await WorkoutRepository.GetAllByUserIdAsync(user.Id);
                        }
                    }
                }
                
                _isInitialized = true;
                StateHasChanged();
            }
        }

        private void OnAddExerciseLogBtnClicked(EditCommandContext<Workout> context)
        {
            SelectedWorkout = context.Item;
            if (SelectedWorkout != null)
            {
                NavigationManager.NavigateTo($"/exerciseLog/add/{SelectedWorkout.Id}");
            }
        }

        private void OnSeeExerciseLogsBtnClicked(EditCommandContext<Workout> context)
        {
            SelectedWorkout = context.Item;
            if (SelectedWorkout != null)
            {
                NavigationManager.NavigateTo($"/exerciseLogs/{SelectedWorkout.Id}");
            }
        }

        private void OnDeleteBtnClicked(DeleteCommandContext<Workout> context)
        {
            SelectedWorkout = context.Item;
            ShowConfirmDialog = true;
        }

        private async Task OnConfirmClose(bool confirmed)
        {
            ShowConfirmDialog = false;

            if (confirmed && SelectedWorkout != null)
            {
                await WorkoutRepository.RemoveAsync(SelectedWorkout.Id);
                if (UserId == null)
                {
                    _workouts = await WorkoutRepository.GetAllAsync();
                }
                else
                {
                    _workouts = await WorkoutRepository.GetAllByUserIdAsync(UserId.Value);
                }
                StateHasChanged();
            }
        }
    }
}
