using LibrarryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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

        public void SwithToMainWindow()
        {
            var main = _serviceProvider.GetRequiredService<MainWindow>();
            main.Show();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != main)
                    window.Close();
            }
        }

        public void SwithToSignInWindow()
        {
            OpenSignInWindow();

            var signIn = _serviceProvider.GetRequiredService<SignInWindow>();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != signIn)
                    window.Close();
            }
        }
    }
}