using System.Windows.Controls;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IUserDialogService
    {
        void OpenSignInWindow();
        void SwitchToSignInWindow();
        void SwitchToMainWindow();
        void SwitchToTestWindow();
        Page GetProfilePage();
        Page GetSettingsPage();
        Page GetBooksPage();
    }
}
