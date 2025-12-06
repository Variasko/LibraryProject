namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IUserDialogService
    {
        void OpenSignInWindow();
        void SwithToSignInWindow();
        void SwithToMainWindow();
    }
}
