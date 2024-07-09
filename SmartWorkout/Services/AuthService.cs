using SmartWorkout.Entities;

public class AuthService
{
    public event Action OnChange;
    public User CurrentUser { get; private set; }

    public void Login(User user)
    {
        CurrentUser = user;
        NotifyStateChanged();
    }

    public void Logout()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    public bool IsLoggedIn => CurrentUser != null;
    public bool IsTrainer => CurrentUser?.isTrainer ?? false;

    private void NotifyStateChanged() => OnChange?.Invoke();
}
