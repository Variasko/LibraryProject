using LibraryDesktop.Infrastructure.Command.Base.Async;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Models.ApiRequestModels;
using LibraryDesktop.Models.ApiResponceModels;
using LibraryDesktop.Statics;
using LibraryDesktop.ViewModels.Base;
using LibraryDesktop.Views.Windows;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Windows.Input;

namespace LibraryDesktop.ViewModels.WindowsViewModels
{
    public class SignInWindowViewModel : BaseViewModel
    {
        public string Title { get; } = "Авторизация";

        private readonly IMessageBoxService _messageBoxService;
        private readonly IUserDialogService _userDialogService;
        private readonly IAuthService _authService;

        public string? Login { get; set; }
        public string? Password { get; set; }

        public ICommand SignInCommand { get; }

        public SignInWindowViewModel() { }

        public SignInWindowViewModel(
            IUserDialogService userDialogService,
            IMessageBoxService messageBoxService,
            IAuthService authService)
        {
            _userDialogService = userDialogService;
            _messageBoxService = messageBoxService;
            _authService = authService;

            SignInCommand = new LambdaAsyncCommand(OnSignInCommandExecute, CanSignInCommandExecute);
        }

        private bool CanSignInCommandExecute(object _) =>
            !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password);

        private async Task OnSignInCommandExecute(object _)
        {
            try
            {
                var employee = await _authService.AuthAsync(new AuthModel { Login = Login!, Password = Password! });

                if (employee == null)
                {
                    _messageBoxService.ShowError("Неверный логин или пароль!");
                    return;
                }

                CurrentSession.CurrentEmployee = employee;
                _userDialogService.SwitchWindow<MainWindow>();
            }
            catch (HttpRequestException ex)
            {
                _messageBoxService.ShowError($"Ошибка подключения к серверу: {ex.Message}");
            }
            catch (Exception ex)
            {
                _messageBoxService.ShowError($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}