using LibrarryDesktop.Helpers; // очепятка, менять не буду
using LibrarryDesktop.Infrastructure.DependencyInjection;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Statics;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LibrarryDesktop;

public partial class App : Application
{

    private IServiceProvider _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _serviceProvider = InitializeServices();
        _serviceProvider.GetRequiredService<IUserDialogService>().OpenSignInWindow();

        _serviceProvider.GetRequiredService<IConfigurationService>().LoadAndApplySettings();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        Application.Current.Shutdown();
    }

    public static IServiceProvider ServiceProvider => ((App)Current)._serviceProvider;

    private static IServiceProvider InitializeServices()
    {
        var services = new ServiceCollection();
        services.RegisterApplicationServices();
        return services.BuildServiceProvider();
    }
}