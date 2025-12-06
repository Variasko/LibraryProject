using LibrarryDesktop.Infrastructure.Services;
using LibrarryDesktop.Infrastructure.Services.Implementation;
using LibrarryDesktop.ViewModels;
using LibrarryDesktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarryDesktop.Infrastructure.DependencyInjection
{
    public static class ServiceRegistrator
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            return services
                .RegisterCoreServices()
                .RegisterViewModels()
                .RegisterWindows();
        }

        private static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserDialogService, UserDialogService>();
            return services;
        }

        private static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<SignInWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();
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

            return services;
        }
    }
}