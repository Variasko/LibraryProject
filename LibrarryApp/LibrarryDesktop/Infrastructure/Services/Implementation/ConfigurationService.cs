using LibrarryDesktop.Helpers;
using LibrarryDesktop.Models.Settings;
using LibrarryDesktop.Statics;
using Newtonsoft.Json;
using System.IO;

namespace LibrarryDesktop.Infrastructure.Services.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        private IThemeService _themeService;

        private const string _settingUri = "settings.json";

        public ConfigurationService(IThemeService themeService)
        {
            _themeService = themeService;
        }

        public SettingsModel LoadSettings()
        {
            var data = File.ReadAllText(_settingUri);
            SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(data);
            return settings;
        }
        public void SaveSettings()
        {
            var json = JsonConvert.SerializeObject(CurrentSettings.Settings);
            File.WriteAllText(_settingUri, json);
        }
        public void LoadAndApplySettings()
        {
            SettingsModel settings = LoadSettings();
            CurrentSettings.Settings = settings;
            _themeService.ChangeTheme(CurrentSettings.Settings.Theme);
        }
    }
}
