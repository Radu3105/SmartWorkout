using Microsoft.AspNetCore.Components;
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
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public AuthService AuthService { get; set; }

        public UserLoginDto UserLoginDto { get; set; } = new();

        public User User { get; set; } = new();

        private bool _failedLogin = false;

        public async Task LoginUser()
        {
            User = await UserRepository.GetByEmailAsync(UserLoginDto.Email);
            if (User == null || UserLoginDto.Password != User.Birthday.Month.ToString() + User.Birthday.Year.ToString())
            {
                _failedLogin = true;
                StateHasChanged();
            }
            else
            {
                _failedLogin = false;
                StateHasChanged();
                AuthService.Login(User);
                await InvokeAsync(() => NavigationManager.NavigateTo("/users"));
            }
        }
    }
}
