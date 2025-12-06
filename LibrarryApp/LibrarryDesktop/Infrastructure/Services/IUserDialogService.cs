namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IUserDialogService
    {
        void OpenSignInWindow();
        void SwitchToSignInWindow();
        void SwitchToMainWindow();
        void SwitchToTestWindow();
    }
}
