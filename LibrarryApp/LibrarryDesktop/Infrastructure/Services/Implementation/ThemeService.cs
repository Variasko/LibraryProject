using LibrarryDesktop.Models.Theme;
using System.Windows;

namespace LibrarryDesktop.Infrastructure.Services.Implementation
{
    public class ThemeService : IThemeService
    {
        public void ChangeTheme(ThemeEnum theme)
        {
            string themeName = theme.ToString();

            Uri themeUri = new Uri($"Themes/{themeName}.xaml", UriKind.Relative);
            ResourceDictionary resourceDictionary = (ResourceDictionary)Application.LoadComponent(themeUri);

            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
