using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExercisesPage : ComponentBase
    {
        [Inject]
        public IExerciseRepository ExerciseRepository { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private  ICollection<Exercise> _exercises;

        private Exercise SelectedExercise { get; set; }
        private bool ShowConfirmDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _exercises = await ExerciseRepository.GetAllAsync();
        }

        private void OnEditBtnClicked(EditCommandContext<Exercise> context)
        {
            var id = context.Item.Id;
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/exercise/edit/{id}");
            }
        }

        private async Task OnDeleteBtnClicked(DeleteCommandContext<Exercise> context)
        {
            SelectedExercise = context.Item;
            ShowConfirmDialog = true;
        }

        private async Task OnConfirmClose(bool confirmed)
        {
            ShowConfirmDialog = false;
            if (confirmed && SelectedExercise != null)
            {
                if (SelectedExercise != null)
                {
                    await ExerciseRepository.RemoveAsync(SelectedExercise.Id);
                    await OnInitializedAsync();
                }
            }
            StateHasChanged();
        }
    }
}
