using CuratorJournal.Desktop.Infrastructure.Commands;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.ViewModels.Base;
using System.Windows.Input;

namespace LibrarryDesktop.ViewModels
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


		public ICommand SignInCommand { get; }

		private bool CanSignInCommandExecute(object p)
			=> !string.IsNullOrEmpty(_login) || !string.IsNullOrEmpty(_password);
		private void OnSignInCommandExecute(object p)
		{
			_userDialogService.SwitchToMainWindow();
		}


		#endregion


		#region Конструктор
		public SignInWindowViewModel() { }
        public SignInWindowViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
			SignInCommand = new LambdaCommand(OnSignInCommandExecute, CanSignInCommandExecute);
        }
        private IUserDialogService _userDialogService;
        #endregion


    }
}
