using BlazorServerAuthenticationAndAuthorization.Authentication;
using Microsoft.AspNetCore.Components;
using SmartWorkout.Components.Services.Interfaces;

namespace SmartWorkout.Components.Layout
{
    public partial class NavMenu : ComponentBase
    {
        [Inject]
        public CustomAuthenticationStateProvider _customAuthenticationStateProvider { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void Logout()
        {
            _customAuthenticationStateProvider.UpdateAuthenticationState(null);
            AuthorizationService.LogOut();
            NavigationManager.NavigateTo("/login");
        }
    }
}
