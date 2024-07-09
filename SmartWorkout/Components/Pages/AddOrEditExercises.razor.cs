using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Interfaces;
using WorkoutApp.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.Repositories.Implementations;

namespace SmartWorkout.Components.Pages
{
    public partial class AddOrEditExercises : ComponentBase
    {
        [Inject]
        public IExerciseRepository ExerciseRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthService AuthService { get; set; }

        [Parameter]
        public int ExerciseId { get; set; }

        public ExerciseDto ExerciseDto { get; set; } = new ExerciseDto();
        public Exercise Exercise { get; set; } = new Exercise();

        private bool IsEdit = false;

        protected override async Task OnParametersSetAsync()
        {
            if (ExerciseId != 0)
            {
                Exercise = await ExerciseRepository.GetByIdAsync(ExerciseId);
                if (Exercise != null)
                {
                    ExerciseDto = ExerciseMapper.ToExerciseDto(Exercise);
                    IsEdit = true;
                }
                else
                {
                    await InvokeAsync(() => NavigationManager.NavigateTo("/exercises"));
                }
            }
        }

        private async Task OnFormSubmitAsync()
        {
            try
            {
                var exercise = ExerciseMapper.ToExercise(ExerciseDto);
                if (IsEdit)
                {
                    var trackedEntity = ExerciseRepository.GetTrackedEntity(exercise.Id);
                    if (trackedEntity != null)
                    {
                        ExerciseRepository.Detach(trackedEntity);
                    }

                    await ExerciseRepository.UpdateAsync(exercise);
                }
                else
                {
                    await ExerciseRepository.AddAsync(exercise);
                }

                await InvokeAsync(() => NavigationManager.NavigateTo("/exercises"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }

    }
}
