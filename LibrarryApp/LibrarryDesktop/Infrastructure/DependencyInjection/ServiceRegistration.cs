using LibraryDesktop.Helpers;
using LibraryDesktop.Infrastructure.Services;
using LibraryDesktop.Infrastructure.Services.Implementation;
using LibraryDesktop.Statics;
using LibraryDesktop.ViewModels.PagesViewModels;
using LibraryDesktop.ViewModels.WindowsViewModels;
using LibraryDesktop.Views.Pages;
using LibraryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace LibraryDesktop.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
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
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddSingleton<IThemeService, ThemeService>();
            return services;
        }

        private static IServiceCollection RegisterHttpClient(this IServiceCollection services)
        {
            services.AddSingleton(serviceProvider =>
            {
                serviceProvider.GetRequiredService<IConfigurationService>().LoadAndApplySettings();
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
            services.AddTransient<BooksPageViewModel>();

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
            services.AddTransient(sp => new BooksPage
            {
                DataContext = sp.GetRequiredService<BooksPageViewModel>()
            });

            return services;
        }
    }
}