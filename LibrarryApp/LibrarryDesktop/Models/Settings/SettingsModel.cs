using LibraryDesktop.Models.Theme;

namespace LibraryDesktop.Models.Settings
{
    public class SettingsModel
    {
        public ThemeEnum Theme { get; set; }
        public ApiSettings Api { get; set; }
    }
}
