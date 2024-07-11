using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;
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

        private bool ShowConfirmDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _users = await UserRepository.GetAllAsync();
        }

        private void OnSeeWorkoutsBtnClicked(EditCommandContext<User> context)
        {
            SelectedUser = context.Item;
            if (SelectedUser != null)
            {
                NavigationManager.NavigateTo($"/workouts/{SelectedUser.Id}");
            }
        }

        private void OnAddWorkoutBtnClicked(EditCommandContext<User> context) 
        {
            SelectedUser = context.Item;
            if (SelectedUser != null)
            {
                NavigationManager.NavigateTo($"/workout/add/{SelectedUser.Id}");
            }
        }

        private void OnEditBtnClicked(EditCommandContext<User> context)
        {
            var id = context.Item.Id;
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/user/edit/{id}");
            }
        }

        private async Task OnDeleteBtnClicked(DeleteCommandContext<User> context)
        {
            SelectedUser = context.Item;
            ShowConfirmDialog = true;
        }

        private async Task OnConfirmClose(bool confirmed)
        {
            ShowConfirmDialog = false;

            if (confirmed && SelectedUser != null)
            {
                if (SelectedUser != null)
                {
                    await UserRepository.RemoveAsync(SelectedUser.Id);
                    await OnInitializedAsync();
                }
            }
            StateHasChanged();
        }        
    }
}

