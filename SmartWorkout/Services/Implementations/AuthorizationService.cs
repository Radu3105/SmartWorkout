using BlazorServerAuthenticationAndAuthorization.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.DTOs;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Interfaces;
using System.Security.Authentication;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Services.Implementations
{
    public class AuthorizationService : Interfaces.IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly CustomAuthenticationStateProvider _customAuthenticationStateProvider;

        public AuthorizationService(IUserRepository userRepository, AuthenticationStateProvider authenticationStateProvider)
        {
            _userRepository = userRepository;
            _customAuthenticationStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
        }

        public static UserDto? CurrentUser { get; set; }

        public async Task Login(UserLoginDto loginDto)
        {
            {
                var userToLogin = await _userRepository.GetByEmailAsync(loginDto.Email);
                if (userToLogin == null)
                {
                    throw new Exception("Wrong username or password");
                }
                if (loginDto.Password == userToLogin.Birthday.ToString("MMyyyy"))
                {
                    CurrentUser = UserMapper.ToUserDto(userToLogin);
                }
                _customAuthenticationStateProvider.UpdateAuthenticationState(userToLogin);
            }
        }

        public UserDto GetCurrentUser()
        {
            return CurrentUser;
        }

        public bool IsUserPresent()
        {
            if (CurrentUser == null)
            {
                return false;
            }

            return true;
        }

        public void LogOut()
        {
            CurrentUser = null;
        }
    }
}