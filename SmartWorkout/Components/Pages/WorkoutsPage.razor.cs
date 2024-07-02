using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class WorkoutsPage : ComponentBase
    {
        [Inject]
        public IWorkoutRepository WorkoutRepository { get; set; }

        private ICollection<Workout> _workouts;

        protected override async Task OnInitializedAsync()
        {
            _workouts = await WorkoutRepository.GetAllAsync();
        }
    }
}
