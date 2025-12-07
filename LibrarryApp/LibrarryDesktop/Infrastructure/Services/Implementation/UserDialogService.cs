using LibrarryDesktop.Views.Pages;
using LibrarryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace LibrarryDesktop.Infrastructure.Services.Implementation
{
    public class UserDialogService : IUserDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        public UserDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void OpenSignInWindow()
        {
            var window = _serviceProvider.GetRequiredService<SignInWindow>();
            window.Show();
        }

        public void SwitchToMainWindow()
        {
            var main = _serviceProvider.GetRequiredService<MainWindow>();
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != main)
                    window.Close();
            }
        }

        public void SwitchToSignInWindow()
        {
            OpenSignInWindow();

            var signIn = _serviceProvider.GetRequiredService<SignInWindow>();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != signIn)
                    window.Close();
            }
        }

        public void SwitchToTestWindow()
        {
            var testWindow = _serviceProvider.GetRequiredService<ViewTestWindow>();
            testWindow.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != testWindow)
                    window.Close();
            }
        }
        public Page GetProfilePage()
        {
            return _serviceProvider.GetRequiredService<ProfilePage>();
        }
    }
}