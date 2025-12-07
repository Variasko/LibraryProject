using System.Diagnostics.Eventing.Reader;
using System.IO;
using LibrarryDesktop.Models.Settings;
using LibrarryDesktop.Statics;
using Newtonsoft.Json;

namespace LibrarryDesktop.Helpers
{
    public class SettingHelper
    {
        private readonly ThemeHelper _themeHelper;
        private const string _settingUri = "settings.json";

        public SettingHelper(ThemeHelper theme)
        {
            _themeHelper = theme;
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
        public void ApplySettings()
        {
            SettingsModel settings = LoadSettings();
            CurrentSettings.Settings = settings;
            _themeHelper.ChangeTheme(CurrentSettings.Settings.Theme);
        }
    }
}
