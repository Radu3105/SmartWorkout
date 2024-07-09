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
    public partial class AddOrEditWorkouts : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthService AuthService { get; set; }

        [Parameter]
        public int UserId { get; set; }

        public WorkoutDto WorkoutDto { get; set; } = new WorkoutDto();
        public Workout Workout { get; set; } = new Workout();

        private bool IsEdit = false;

        private async Task OnFormSubmitAsync()
        {
            try
            {
                var workout = WorkoutMapper.ToWorkout(WorkoutDto);
                workout.UserId = UserId;
                if (IsEdit)
                {
                    var trackedEntity = WorkoutRepository.GetTrackedEntity(workout.Id);
                    if (trackedEntity != null)
                    {
                        WorkoutRepository.Detach(trackedEntity);
                    }

                    await WorkoutRepository.UpdateAsync(workout);
                }
                else
                {
                    await WorkoutRepository.AddAsync(workout);
                }

                await InvokeAsync(() => NavigationManager.NavigateTo("/workouts"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }

    }
}
