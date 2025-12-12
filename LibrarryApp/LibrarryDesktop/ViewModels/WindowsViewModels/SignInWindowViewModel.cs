using LibraryDesktop.Infrastructure.Command.Base.Async;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Models.ApiRequestModels;
using LibraryDesktop.Models.ApiResponceModels;
using LibraryDesktop.Statics;
using LibraryDesktop.ViewModels.Base;
using LibraryDesktop.Views.Windows;
using System.Net.Http;
using System.Windows.Input;

namespace LibraryDesktop.ViewModels.WindowsViewModels
{
    public class SignInWindowViewModel : BaseViewModel
    {

		#region Title : string - Заголовок окна
		public string Title { get; } = "Авторизация";
		#endregion


		#region Свойства


		#region Login : string - Логин пользователя

		/// <summary> Логин пользователя </summary>
		private string _login;

		/// <summary> Логин пользователя </summary>
		public string Login
		{
			get { return _login; }
			set
			{
				Set(ref _login, value);
			}
		}
		#endregion

		#region Password : string - Пароль пользователя

		/// <summary> Пароль пользователя </summary>
		private string _password;

		/// <summary> Пароль пользователя </summary>
		public string Password
		{
			get { return _password; }
			set
			{
				Set(ref _password, value);
			}
		}
        #endregion


        #endregion


        #region Команды


        #region SignIn
        public ICommand SignInCommand { get; }

        private bool CanSignInCommandExecute(object p)
            => !string.IsNullOrWhiteSpace(_login) || !string.IsNullOrWhiteSpace(_password);
        private async Task OnSignInCommandExecute(object p)
        {
            AuthModel authRequest = new AuthModel { Login = _login, Password = _password };

            try
            {
                var employee = await _authService.AuthAsync(authRequest);
                if (employee == null)
                {
                    _messageBoxService.ShowError("Неверный логин или пароль!");
                    return;
                }
                Post post = await _postService.GetPostById(employee.PostId ?? -1);

                CurrentSession.CurrentEmployee = employee;
                CurrentSession.CurrentPost = post;

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
        #endregion

        #endregion


        #region Конструктор
        public SignInWindowViewModel() { }
        public SignInWindowViewModel(
				IUserDialogService userDialogService,
                IMessageBoxService messageBoxService,
				IAuthService authService,
                IPostService postService
			)
        {
            _messageBoxService = messageBoxService;
            _userDialogService = userDialogService;
			_authService = authService;
            _postService = postService;

			SignInCommand = new LambdaAsyncCommand(OnSignInCommandExecute, CanSignInCommandExecute);
        }

        private IUserDialogService _userDialogService;
        private IMessageBoxService _messageBoxService;

		private IAuthService _authService;
        private IPostService _postService;
        #endregion

    }
}
