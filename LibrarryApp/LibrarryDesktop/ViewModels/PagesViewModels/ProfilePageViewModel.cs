using LibraryDesktop.Infrastructure.Command.Base.Sync;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Statics;
using LibraryDesktop.ViewModels.Base;
using LibraryDesktop.Views.Windows;
using System.Windows.Input;

namespace LibraryDesktop.ViewModels.PagesViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public string Surname { get; }
        public string Name { get; }
        public string? Patronymic { get; }
        public string PostName { get; }

        public ICommand SignOutCommand { get; }

        public ProfilePageViewModel() { }

        public ProfilePageViewModel(IUserDialogService userDialogService)
        {
            var employee = CurrentSession.CurrentEmployee;
            Surname = employee.Surname;
            Name = employee.Name;
            Patronymic = employee.Patronymic;
            PostName = employee.Post.Name;

            SignOutCommand = new LambdaCommand(_ => userDialogService.SwitchWindow<SignInWindow>());
        }
    }
}