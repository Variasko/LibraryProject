using LibrarryDesktop.Helpers;
using LibrarryDesktop.Heplers;
using LibrarryDesktop.Infrastructure.Command.Base.Sync;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Models.Settings;
using LibrarryDesktop.Models.Theme;
using LibrarryDesktop.Statics;
using LibrarryDesktop.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace LibrarryDesktop.ViewModels.PagesViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {

        #region Свойства

        public List<ThemeEnumItem> ThemeEnums { get; } = new List<ThemeEnumItem>
        {
            new ThemeEnumItem { ThemeName = "Светлая", ThemeEnum = ThemeEnum.Light},
            new ThemeEnumItem { ThemeName = "Тёмная", ThemeEnum = ThemeEnum.Dark}
        };


        #region SelectedTheme : ThemeEnumItem - Выбранная тема

        /// <summary> Выбранная тема </summary>
        private ThemeEnumItem _selectedTheme;

        /// <summary> Выбранная тема </summary>
        public ThemeEnumItem SelectedTheme
        {
            get { return _selectedTheme; }
            set
            {
                Set(ref _selectedTheme, value);
            }
        }
        #endregion


        #region HostAddress : string - Адрес подключения к апи

        /// <summary> Адрес подключения к апи </summary>
        private string _hostAddress = CurrentSettings.Settings.Api.BaseUrl;

        /// <summary> Адрес подключения к апи </summary>
        public string HostAddress
        {
            get { return _hostAddress; }
            set
            {
                Set(ref _hostAddress, value);
            }
        }
        #endregion


        #region TimeOut : string - Таймаут подключения к апи

        /// <summary> Таймаут подключения к апи </summary>
        private string _timeOut = CurrentSettings.Settings.Api.TimeoutSeconds.ToString();

        /// <summary> Таймаут подключения к апи </summary>
        public string TimeOut
        {
            get { return _timeOut; }
            set
            {
                Set(ref _timeOut, value);
            }
        }
        #endregion

        #endregion

        #region Команды


        public ICommand SaveSettings { get; }

        private bool CanSaveSettingsExecute(object p) => true;
        private void OnSaveSettingsExecute(object p)
        {
            SettingsModel settings = CurrentSettings.Settings;

            settings.Theme = _selectedTheme.ThemeEnum;
            settings.Api.BaseUrl = _hostAddress;
            settings.Api.TimeoutSeconds = Convert.ToInt32(_timeOut);

            CurrentSettings.Settings = settings;

            _configurationService.SaveSettings();
            _configurationService.LoadAndApplySettings();
        }


        #endregion

        #region Конструктор
        public SettingsPageViewModel() { }
        public SettingsPageViewModel(
            IUserDialogService userDialogService,
            IConfigurationService configurationService
        )
        {
            var currentTheme = CurrentSettings.Settings.Theme; 
            SelectedTheme = ThemeEnums
                .FirstOrDefault(te => te.ThemeEnum == currentTheme) ?? ThemeEnums[0]; 

            _messageBoxHelper = new MessageBoxHelper();

            _userDialogService = userDialogService;
            _configurationService = configurationService;

            SaveSettings = new LambdaCommand(OnSaveSettingsExecute, CanSaveSettingsExecute);
        }
        private MessageBoxHelper _messageBoxHelper;

        private IUserDialogService _userDialogService;
        private IConfigurationService _configurationService;
        #endregion

    }
}
