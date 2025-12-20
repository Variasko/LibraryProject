using LibraryDesktop.Infrastructure.Command.Base.Sync;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Models.ApiResponceModels;
using LibraryDesktop.ViewModels.Base;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryDesktop.ViewModels.PagesViewModels
{
    public class BooksPageViewModel : BaseViewModel
    {
        private IBookService _bookService;
        private IMessageBoxService _messageBoxService;


        private List<Book> _books;
        public List<Book> Books
        {
            get { return _books; }
            set
            {
                Set(ref _books, value);
            }
        }

        public BooksPageViewModel() { }
        public BooksPageViewModel(
                IUserDialogService userDialogService,
                IMessageBoxService messageBoxService,
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

        public void OnBookCardClicked(object card)
        {
            
        }
    }
}
