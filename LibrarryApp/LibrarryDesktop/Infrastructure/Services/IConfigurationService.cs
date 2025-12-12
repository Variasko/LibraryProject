using LibraryDesktop.Models.Settings;

namespace LibraryDesktop.Infrastructure.Services
{
    public interface IConfigurationService
    {
        void LoadAndApplySettings();
        void SaveSettings();
    }
}
