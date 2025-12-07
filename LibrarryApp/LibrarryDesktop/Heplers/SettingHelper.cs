using System.Diagnostics.Eventing.Reader;
using System.IO;
using LibrarryDesktop.Models.Settings;
using LibrarryDesktop.Statics;
using Newtonsoft.Json;

namespace LibrarryDesktop.Helpers
{
    public class SettingHelper
    {
        private const string _settingUri = "settings.json";
        public SettingsModel LoadSettings()
        {
            var data = File.ReadAllText(_settingUri);
            SettingsModel settings = JsonConvert.DeserializeObject<SettingsModel>(data);
            return settings;
        }
        public void SaveSettings(SettingsModel settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(_settingUri, json);
        }
        public void ApplySettings()
        {
            SettingsModel settings = LoadSettings();
            CurrentSettings.Settings = settings;
        }
    }
}
