using LibrarryDesktop.Models.Theme;
using System.Windows;

namespace LibrarryDesktop.Helers
{
    public class ThemeHelper
    {
        public void ChangeTheme(ThemeEnum theme)
        {
            string themeName = theme.ToString();

            Uri themeUri = new Uri($"Styles/{themeName}Theme.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)Application.LoadComponent(themeUri);

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
