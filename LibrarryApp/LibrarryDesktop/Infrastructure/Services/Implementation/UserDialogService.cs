using LibraryDesktop.Views.Pages;
using LibraryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace LibraryDesktop.Infrastructure.Services.Implementation
{
    public class UserDialogService : IUserDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        private Window _currentWindow;

        public UserDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SwitchWindow<T>() where T : Window
        {
            try
            {
                var window = _serviceProvider.GetRequiredService<T>();

                if (_currentWindow != null) _currentWindow.Close();
                
                _currentWindow = window;
                _currentWindow.Show();

            } catch (InvalidOperationException ex)
            {
                _serviceProvider.GetRequiredService<IMessageBoxService>().ShowError(ex.Message);
            }
            
        }
        public Page GetPage<T>() where T : Page
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}