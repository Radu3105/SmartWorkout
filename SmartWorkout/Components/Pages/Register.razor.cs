using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Interfaces;
using WorkoutApp.DTOs;

namespace SmartWorkout.Components.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public required IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int UserId { get; set; }

        public UserAuthenticationDto UserAuthenticationDto { get; set; } = new();
        public User User { get; set; } = new();

        private bool IsEdit = false;

        protected override async Task OnParametersSetAsync()
        {
            if (UserId != 0)
            {
                User = await UserRepository.GetByIdAsync(UserId);
                if (User != null)
                {
                    UserAuthenticationDto = UserAuthenticationMapper.ToUserAuthenticationDto(User);
                    IsEdit = true;
                }
                else
                {
                    await InvokeAsync(() => NavigationManager.NavigateTo("/"));
                }
            }
        }

        private async Task OnFormSubmitAsync()
        {
            try
            {
                var user = UserAuthenticationMapper.ToUser(UserAuthenticationDto);
                if (IsEdit)
                {
                    var trackedEntity = UserRepository.GetTrackedEntity(user.Id);
                    if (trackedEntity != null)
                    {
                        UserRepository.Detach(trackedEntity);
                    }

                    await UserRepository.UpdateAsync(user);
                }
                else
                {
                    await UserRepository.AddAsync(user);
                }

                await InvokeAsync(() => NavigationManager.NavigateTo("/"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }

    }
}
