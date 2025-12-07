using LibrarryDesktop.Helpers;
using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Infrastructure.Services.Implementation;
using LibrarryDesktop.Statics;
using LibrarryDesktop.ViewModels.PagesViewModels;
using LibrarryDesktop.ViewModels.WindowsViewModels;
using LibrarryDesktop.Views.Pages;
using LibrarryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace LibrarryDesktop.Infrastructure.DependencyInjection
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            return services
                .RegisterCoreServices()
                .RegisterHttpClient()
                .RegisterApiServices()
                .RegisterViewModels()
                .RegisterWindows()
                .RegisterPages();
        }

        private static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserDialogService, UserDialogService>();
            services.AddSingleton<ThemeHelper>();
            services.AddSingleton<SettingHelper>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            return services;
        }

        private static IServiceCollection RegisterHttpClient(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                var settings = CurrentSettings.Settings.Api;

                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(settings.BaseUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(settings.TimeoutSeconds);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                return httpClient;
            });

            return services;
        }

        private static IServiceCollection RegisterApiServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPostService, PostService>();

            return services;
        }

        private static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SignInWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<ViewTestWindowViewModel>();

            services.AddTransient<ProfilePageViewModel>();
            services.AddTransient<SettingsPageViewModel>();

            return services;
        }

        private static IServiceCollection RegisterWindows(this IServiceCollection services)
        {
            services.AddTransient(sp => new SignInWindow
            {
                DataContext = sp.GetRequiredService<SignInWindowViewModel>()
            });

            services.AddTransient(sp => new MainWindow
            {
                DataContext = sp.GetRequiredService<MainWindowViewModel>()
            });

            services.AddTransient(sp => new ViewTestWindow
            {
                DataContext = sp.GetRequiredService<ViewTestWindowViewModel>()
            });

            return services;
        }

        private static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient(sp => new ProfilePage
            {
                DataContext = sp.GetRequiredService<ProfilePageViewModel>()
            });
            services.AddTransient(sp => new SettingsPage
            {
                DataContext = sp.GetRequiredService<SettingsPageViewModel>()
            });

            return services;
        }
    }
}