using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
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
        public AuthService AuthService { get; set; }

        [Parameter]
        public int UserId { get; set; }

        private ICollection<Workout> _workouts;
        public Workout SelectedWorkout { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _workouts = await WorkoutRepository.GetAllAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (UserId != 0)
            {
                _workouts = await WorkoutRepository.GetAllByUserIdAsync(UserId);
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

        private async Task OnDeleteBtnClicked(DeleteCommandContext<Workout> context)
        {
            SelectedWorkout = context.Item;
            if (SelectedWorkout != null)
            {
                await WorkoutRepository.RemoveAsync(SelectedWorkout.Id);
                await OnInitializedAsync();
            }
        }
    }
}
