using LibrarryDesktop.Infrastructure.API;
using LibrarryDesktop.Models.ApiResponceModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace LibrarryDesktop.Infrastructure.Services.Implementation
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;
        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Post> GetPostById(int postId, CancellationToken cancellationToken = default)
        {
            if (postId == 0)
                throw new ArgumentException(nameof(postId));

            var response = await _httpClient.GetAsync(
                Routers.Posts.GetPostById.Replace("{0}", postId.ToString()),
                cancellationToken
            );

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync(cancellationToken);
                var post = JsonConvert.DeserializeObject<Post>(json);
                return post;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // API вернул 401 - неправильные логин/пароль
                // Возвращаем null, чтобы ViewModel могла обработать это как ошибку аутентификации
                return null;
            }
            else
            {
                response.EnsureSuccessStatusCode();
                return null;
            }
        }
    }
}
