using System.Windows;

namespace LibrarryDesktop.Heplers
{
    public class MessageBoxHelper
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
