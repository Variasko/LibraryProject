using System.Windows;

namespace LibraryDesktop.Infrastructure.Services.Implementation
{
    public class MessageBoxService : IMessageBoxService
    {
        public void ShowInfo(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void ShowWarn(string message)
        {
            MessageBox.Show(message, "Осторожно!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
