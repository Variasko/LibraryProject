using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.ViewModels.Base;
using System.Windows.Controls;

namespace LibrarryDesktop.ViewModels.WindowsViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region Title : string - Заголовок окна
        public string Title { get; } = "Городская библиотека";
        #endregion


        #region Свойства


        #region Страницы

        #region ProfilePage : Page - Страница профиля

        /// <summary> Страница профиля </summary>
        private Page _profilePage;

        /// <summary> Страница профиля </summary>
        public Page ProfilePage
        {
            get { return _profilePage; }
            set
            {
                Set(ref _profilePage, value);
            }
        }
        #endregion
        #endregion

        #endregion


        #region Конструктор
        public MainWindowViewModel() { }
        public MainWindowViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;

            _profilePage = _userDialogService.GetProfilePage();
        }
        private IUserDialogService _userDialogService;
        #endregion

    }
}
