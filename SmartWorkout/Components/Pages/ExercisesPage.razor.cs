using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class ExercisesPage : ComponentBase
    {
        [Inject]
        public IExerciseRepository ExerciseRepository { get; set; }

        private  ICollection<Exercise> _exercises;

        protected override async Task OnInitializedAsync()
        {
            _exercises = await ExerciseRepository.GetAllAsync();
        }
    }
}
