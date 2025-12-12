using LibraryDesktop.Models.ApiResponceModels;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IPostService
    {
        /// <summary>
        /// Получает название должности по ID.
        /// </summary>
        /// <param name="postId">Id должности</param>
        /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
        /// <returns>Объект Employee, если аутентификация успешна, иначе null.</returns>
        Task<Post> GetPostById(int postId, CancellationToken cancellationToken = default);
    }
}
