using Microsoft.AspNetCore.Components;
using SmartWorkout.Components.Services.Interfaces;
using SmartWorkout.Entities;
using SmartWorkout.Repositories.Implementations;

namespace SmartWorkout.Components.Layout
{
    public partial class MainLayout
    {
        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        private bool _isUserLoggedIn;

        protected override void OnParametersSet()
        {
            _isUserLoggedIn = AuthorizationService.IsUserPresent();
        }
    }
}
