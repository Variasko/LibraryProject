using LibrarryDesktop.Models.Theme;

namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IThemeService
    {
        void ChangeTheme(ThemeEnum themeName);
    }
}
