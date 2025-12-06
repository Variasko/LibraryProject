using LibrarryDesktop.Helers; // очепятка, менять не буду
using LibrarryDesktop.Infrastructure.DependencyInjection;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Statics;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LibrarryDesktop;

public partial class App : Application
{
    private SettingHelper _sh = new SettingHelper();
    private ThemeHelper _th = new ThemeHelper();
    private IServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _sh.ApplySettings();
        _th.ChangeTheme(Settings.CurrentSettings.Theme);

        _serviceProvider = InitializeServices();
        _serviceProvider.GetRequiredService<IUserDialogService>().OpenSignInWindow();
    }

    public static IServiceProvider ServiceProvider => ((App)Current)._serviceProvider;

    private static IServiceProvider InitializeServices()
    {
        var services = new ServiceCollection();
        services.RegisterApplicationServices();
        return services.BuildServiceProvider();
    }
}