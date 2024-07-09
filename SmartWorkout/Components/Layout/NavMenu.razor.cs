using Microsoft.AspNetCore.Components;
using SmartWorkout.Entities;

namespace SmartWorkout.Components.Layout
{
    public partial class NavMenu : ComponentBase
    {
        [Inject]
        public AuthService AuthService { get; set; }

        protected override void OnInitialized()
        {
            AuthService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            AuthService.OnChange -= StateHasChanged;
        }
    }
}
