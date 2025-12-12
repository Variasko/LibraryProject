using LibraryDesktop.Helpers; // очепятка, менять не буду
using LibraryDesktop.Infrastructure.DependencyInjection;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Statics;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LibraryDesktop;

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