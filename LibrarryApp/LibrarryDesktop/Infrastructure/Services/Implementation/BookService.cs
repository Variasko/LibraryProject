using LibraryDesktop.Infrastructure.API;
using LibraryDesktop.Models.ApiResponceModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace LibraryDesktop.Infrastructure.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Book>> GetBooksAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(Routers.Books.GetBooks, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                var books = JsonConvert.DeserializeObject<List<Book>>(jsonString);
                return books ?? new List<Book>();
            }

            
            response.EnsureSuccessStatusCode();
            return new List<Book>();
        }
    }
}