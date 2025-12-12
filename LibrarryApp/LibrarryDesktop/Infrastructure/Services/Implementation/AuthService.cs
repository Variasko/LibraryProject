using LibraryDesktop.Infrastructure.API;
using LibraryDesktop.Models.ApiRequestModels;
using LibraryDesktop.Models.ApiResponceModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace LibraryDesktop.Infrastructure.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Employee> AuthAsync(AuthModel authRequest, CancellationToken cancellationToken = default)
        {
            if (authRequest == null)
                throw new ArgumentException(nameof(authRequest));

            var response = await _httpClient.PostAsJsonAsync(
                    Routers.Auth.Authorization,
                    authRequest,
                    cancellationToken
                );
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
                var employee = JsonConvert.DeserializeObject<Employee>(jsonString);

                return employee;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
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
