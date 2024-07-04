using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;
using SmartWorkout.Mappers;
using SmartWorkout.Repositories.Interfaces;
using WorkoutApp.DTOs;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SmartWorkout.Components.Pages
{
    public partial class AddOrEditUsers : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int UserId { get; set; }

        public UserDto UserDto { get; set; } = new UserDto();
        public User User { get; set; } = new User();

        private bool IsEdit = false;

        protected override async Task OnParametersSetAsync()
        {
            if (UserId != 0)
            {
                User = await UserRepository.GetByIdAsync(UserId);
                if (User != null)
                {
                    UserDto = UserMapper.ToUserDto(User);
                    IsEdit = true;
                }
                else
                {
                    await InvokeAsync(() => NavigationManager.NavigateTo("/users"));
                }
            }
        }

        private async Task OnFormSubmitAsync()
        {
            try
            {
                var user = UserMapper.ToUser(UserDto);
                Console.WriteLine($"User: {user.Id}, {user.FirstName}, {user.LastName}, {user.Gender}, {user.Birthday}");
                if (IsEdit)
                {
                    await UserRepository.UpdateAsync(user);
                }
                else
                {
                    await UserRepository.AddAsync(user);
                }

                await InvokeAsync(() => NavigationManager.NavigateTo("/users"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving user: {ex.Message}");
            }
        }
    }
}
