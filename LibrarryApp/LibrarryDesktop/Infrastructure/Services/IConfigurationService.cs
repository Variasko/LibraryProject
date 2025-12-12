using LibrarryDesktop.Models.Settings;

namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IConfigurationService
    {
        void LoadAndApplySettings();
        void SaveSettings();
    }
}
