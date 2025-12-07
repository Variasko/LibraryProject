using LibrarryDesktop.Helpers;
using LibrarryDesktop.Models.Settings;
using LibrarryDesktop.Statics;

namespace LibrarryDesktop.Infrastructure.Services.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly SettingHelper _settingHelper;

        public ConfigurationService(SettingHelper settingHelper)
        {
            _settingHelper = settingHelper ?? throw new ArgumentNullException(nameof(settingHelper));
            _settingHelper.ApplySettings();
        }

        public SettingsModel Setting => CurrentSettings.Settings;

        public void SaveSettings()
        {
            _settingHelper.SaveSettings(Setting);
        }
    }
}
