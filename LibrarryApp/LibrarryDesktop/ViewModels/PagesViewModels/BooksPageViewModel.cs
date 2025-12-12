using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.ViewModels.Base;

namespace LibraryDesktop.ViewModels.PagesViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        #region Свойства

        #endregion

        #region Команды

        #endregion

        #region Конструктор
        public BooksPageViewModel(){ }
        public BooksPageViewModel(
                IUserDialogService userDialogService
            )
        {
            _userDialogService = userDialogService;
        }

        private IUserDialogService _userDialogService;

        #endregion
    }
}
