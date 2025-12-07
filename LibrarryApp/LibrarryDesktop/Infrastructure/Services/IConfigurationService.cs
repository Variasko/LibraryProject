using LibrarryDesktop.Models.Settings;

namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IConfigurationService
    {
        SettingsModel Setting { get; }
        void SaveSettings();
    }
}
