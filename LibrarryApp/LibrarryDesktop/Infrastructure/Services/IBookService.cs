using LibraryDesktop.Models.ApiResponceModels;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken = default);
    }
}
