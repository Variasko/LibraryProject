using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.ViewModels.Base;
using LibraryDesktop.Views.Pages;
using System.Windows.Controls;

namespace LibraryDesktop.ViewModels.WindowsViewModels
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

        #region BooksPage : Page - Страница со всеми книгами

        /// <summary> Страница со всеми книгами </summary>
        private Page _booksPage;

        /// <summary> Страница со всеми книгами </summary>
        public Page BooksPage
        {
            get { return _booksPage; }
            set
            {
                Set(ref _booksPage, value);
            }
        }
        #endregion

        #region SettingsPage : Page - Страница настроек

        /// <summary> Страница настроек </summary>
        private Page _settingsPage;

        /// <summary> Страница настроек </summary>
        public Page SettingsPage
        {
            get { return _settingsPage; }
            set
            {
                Set(ref _settingsPage, value);
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

            _profilePage = _userDialogService.GetPage<ProfilePage>();
            _booksPage = _userDialogService.GetPage<BooksPage>():
            _settingsPage = _userDialogService.GetPage<SettingsPage>();
        }
        private IUserDialogService _userDialogService;
        #endregion

    }
}
