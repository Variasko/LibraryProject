using LibrarryDesktop.Models.Settings;

namespace LibrarryDesktop.Infrastructure.Services
{
    public interface IConfigurationService
    {
        void ApplySettings();
        void SaveSettings();
    }
}
