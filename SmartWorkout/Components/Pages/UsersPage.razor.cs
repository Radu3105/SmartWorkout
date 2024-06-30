using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class UsersPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        private ICollection<User> _users;

        protected override async Task OnInitializedAsync()
        {
            _users = await UserRepository.GetAllAsync();
        }
    }
}
