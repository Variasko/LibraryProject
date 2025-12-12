using LibraryDesktop.Models.Theme;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IThemeService
    {
        void ChangeTheme(ThemeEnum themeName);
    }
}
