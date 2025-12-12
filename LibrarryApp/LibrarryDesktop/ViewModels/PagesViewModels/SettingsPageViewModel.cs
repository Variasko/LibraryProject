using LibraryDesktop.Infrastructure.Command.Base.Sync;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Models.Settings;
using LibraryDesktop.Models.Theme;
using LibraryDesktop.Statics;
using LibraryDesktop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace LibraryDesktop.ViewModels.PagesViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        private readonly IConfigurationService _configurationService;
        private readonly IMessageBoxService _messageBoxService;

        public List<ThemeEnumItem> ThemeEnums { get; } = new()
        {
            new() { ThemeName = "Светлая", ThemeEnum = ThemeEnum.Light },
            new() { ThemeName = "Тёмная", ThemeEnum = ThemeEnum.Dark }
        };

        public ThemeEnumItem? SelectedTheme { get; set; }

        public string HostAddress { get; set; }
        public string TimeOut { get; set; }

        public ICommand SaveSettings { get; }

        public SettingsPageViewModel() { }

        public SettingsPageViewModel(
            IUserDialogService userDialogService,
            IConfigurationService configurationService,
            IMessageBoxService messageBoxService)
        {
            _configurationService = configurationService;
            _messageBoxService = messageBoxService;

            var settings = CurrentSettings.Settings;
            HostAddress = settings.Api.BaseUrl;
            TimeOut = settings.Api.TimeoutSeconds.ToString();
            SelectedTheme = ThemeEnums.FirstOrDefault(t => t.ThemeEnum == settings.Theme) ?? ThemeEnums[0];

            SaveSettings = new LambdaCommand(OnSaveSettingsExecute);
        }

        private void OnSaveSettingsExecute(object _)
        {
            if (!int.TryParse(TimeOut, out var timeout) || timeout <= 0)
            {
                _messageBoxService.ShowError("Таймаут должен быть положительным числом.");
                return;
            }

            var settings = CurrentSettings.Settings;
            settings.Theme = SelectedTheme?.ThemeEnum ?? ThemeEnum.Light;
            settings.Api.BaseUrl = HostAddress;
            settings.Api.TimeoutSeconds = timeout;

            CurrentSettings.Settings = settings;
            _configurationService.SaveSettings();
            _configurationService.LoadAndApplySettings();
        }
    }
}