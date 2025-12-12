namespace LibraryDesktop.Infrastructure.Services
{
    public interface IMessageBoxService
    {
        void ShowInfo(string message);
        void ShowError(string message);
        void ShowWarn(string message);
    }
}
