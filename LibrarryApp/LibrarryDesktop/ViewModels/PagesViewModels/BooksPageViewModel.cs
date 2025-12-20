using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Models.ApiResponceModels;
using LibraryDesktop.ViewModels.Base;

namespace LibraryDesktop.ViewModels.PagesViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        private IBookService _bookService;


        #region Books : ObservableCollection - Список книг

        /// <summary> Список книг </summary>
        private List<Book> _books;

        /// <summary> Список книг </summary>
        public List<Book> Books
        {
            get { return _books; }
            set
            {
                Set(ref _books, value);
            }
        }
        #endregion

        public BooksPageViewModel() { }
        public BooksPageViewModel(
                IUserDialogService userDialogService,
                IBookService bookService
            )
        {
            _bookService = bookService;

            LoadBooksAsync();
        }

        private async void LoadBooksAsync()
        {
            Books = await _bookService.GetBooksAsync();
        }
    }
}
