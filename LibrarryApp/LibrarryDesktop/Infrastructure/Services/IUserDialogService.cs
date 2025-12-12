using System.Windows;
using System.Windows.Controls;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IUserDialogService
    {
        void SwitchWindow<T>() where T : Window;
        Page GetPage<T>() where T : Page;
    }
}
