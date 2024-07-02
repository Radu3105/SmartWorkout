using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class AddOrEditUsers : ComponentBase
    {
        [Inject]
        public IUserRepository userRepository { get; set; }

        [SupplyParameterFromForm]
        public User User { get; set; } = new User();

        public async Task AddUserAsync()
        {
            await userRepository.AddAsync(User);
        }
    }
}
