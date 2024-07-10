using Microsoft.AspNetCore.Components;
using SmartWorkout.Components.Services.Implementations;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
using SmartWorkout.Repositories.Interfaces;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Pages
{
    public partial class LoginPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [SupplyParameterFromForm]
        public UserLoginDto UserLoginDto { get; set; } = new();

        private bool _failedLogin = false;
        private UserDto? _currentUser;

        protected override async Task OnInitializedAsync()
        {
            if (_currentUser != null)
            {
                if (_currentUser.IsTrainer == true)
                {
                    NavigationManager.NavigateTo("/users", true);
                }
                else
                {
                    NavigationManager.NavigateTo("/exerciseLogs", true);
                }
            }
        }

        public async Task LoginUser()
        {
            try
            {
                await AuthorizationService.Login(UserLoginDto);

                _currentUser = AuthorizationService.GetCurrentUser();
                if (_currentUser != null)
                {
                    if (_currentUser.IsTrainer == true)
                    {
                        NavigationManager.NavigateTo("/users", true);
                    }
                    else
                    {
                        NavigationManager.NavigateTo("/exerciseLogs", true);
                    }
                    _failedLogin = false;
                }
                else
                {
                    _failedLogin = true;
                }
            }
            catch (Exception e)
            {
                _failedLogin = true;
                Console.WriteLine(e);
            }
        }
    }
}
