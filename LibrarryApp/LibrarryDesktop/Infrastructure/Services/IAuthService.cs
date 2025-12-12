using LibraryDesktop.Models.ApiRequestModels;
using LibraryDesktop.Models.ApiResponceModels;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Аутентифицирует пользователя по логину и паролю.
        /// </summary>
        /// <param name="authRequest">Данные для аутентификации (логин и пароль).</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Объект Employee, если аутентификация успешна, иначе null.</returns>
        Task<Employee> AuthAsync(AuthModel authRequest, CancellationToken cancellationToken = default);
    }
}
