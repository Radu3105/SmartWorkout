using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class AddOrEditExercises : ComponentBase
    {
        [Inject]
        public IExerciseRepository exerciseRepository { get; set; }

        [SupplyParameterFromForm]
        public Exercise Exercise { get; set; } = new Exercise();

        public async Task AddExerciseAsync()
        {
            await exerciseRepository.AddAsync(Exercise);
        }
    }
}
