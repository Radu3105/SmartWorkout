using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Interfaces;

namespace SmartWorkout.Components.Pages
{
    public partial class UsersPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        private NavigationManager NavigationManager {  get; set; }

        private ICollection<User> _users;
        private User SelectedUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _users = await UserRepository.GetAllAsync();
        }

        private void OnEditBtnClicked(EditCommandContext<User> context)
        {
            var id = context.Item.Id;
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/user/edit/{id}");
            }
        }

        private async Task HandleDeleteConfirm(bool confirmed)
        {
            if (confirmed)
            {
                await UserRepository.RemoveAsync(SelectedUser.Id);
            }
        }
    }
}
