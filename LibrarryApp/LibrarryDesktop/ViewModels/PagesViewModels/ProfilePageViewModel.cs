using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Statics;
using LibrarryDesktop.ViewModels.Base;

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

		#endregion

		#region Конструктор
		public ProfilePageViewModel() { }
        public ProfilePageViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
        }
        private IUserDialogService _userDialogService;
        #endregion

    }
}
