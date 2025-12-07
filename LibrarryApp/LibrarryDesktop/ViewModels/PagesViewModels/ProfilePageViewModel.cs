using LibrarryDesktop.Infrastructure.Command.Base.Sync;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Statics;
using LibrarryDesktop.ViewModels.Base;
using System.Windows.Input;

namespace LibrarryDesktop.ViewModels.PagesViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {

		#region Свойства


		#region Surname : string - Фамилия зашедшего

		/// <summary> Фамилия зашедшего </summary>
		private string _surname = CurrentSession.CurrentEmployee.Surname;

		/// <summary> Фамилия зашедшего </summary>
		public string Surname
		{
			get { return _surname; }
			set
			{
				Set(ref _surname, value);
			}
		}
		#endregion

		#region Name : string - Имя зашедшего

		/// <summary> Имя зашедшего </summary>
		private string _name = CurrentSession.CurrentEmployee.Name;

		/// <summary> Имя зашедшего </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				Set(ref _name, value);
			}
		}
		#endregion

		#region Patronymic : string - Отчество зашедшего

		/// <summary> Отчество зашедшего </summary>
		private string _patronymic = CurrentSession.CurrentEmployee.Patronymic;

		/// <summary> Отчество зашедшего </summary>
		public string Patronymic
		{
			get { return _patronymic; }
			set
			{
				Set(ref _patronymic, value);
			}
		}
		#endregion

		#region PostName : string - Название должности зашедшего

		/// <summary> Название должности зашедшего </summary>
		private string _postName = CurrentSession.CurrentPost.Name;

		/// <summary> Название должности зашедшего </summary>
		public string PostName
		{
			get { return _postName; }
			set
			{
				Set(ref _postName, value);
			}
		}
        #endregion

        #endregion


        #region Команды


        #region SignOut
        public ICommand SignOutCommand { get; }

        private bool CanSignOutCommandExecute(object p) => true;
        private void OnSignOutCommandExecute(object p)
        {
            _userDialogService.SwitchToSignInWindow();
        }

        #endregion


        #endregion

        #region Конструктор
        public ProfilePageViewModel() { }
        public ProfilePageViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;

			SignOutCommand = new LambdaCommand(OnSignOutCommandExecute, CanSignOutCommandExecute);
        }
        private IUserDialogService _userDialogService;
        #endregion

    }
}
