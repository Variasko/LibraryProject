using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.ViewModels.Base;
using LibraryDesktop.Views.Pages;
using System.Windows.Controls;

namespace LibraryDesktop.ViewModels.WindowsViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string Title { get; } = "Городская библиотека";

        public Page ProfilePage { get; }
        public Page BooksPage { get; }
        public Page SettingsPage { get; }

        public MainWindowViewModel() { }
        
        public MainWindowViewModel(IUserDialogService userDialogService)
        {
            ProfilePage = userDialogService.GetPage<ProfilePage>();
            BooksPage = userDialogService.GetPage<BooksPage>();
            SettingsPage = userDialogService.GetPage<SettingsPage>();
        }
    }
}