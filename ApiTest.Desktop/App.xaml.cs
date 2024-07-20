using ApiTest.Desktop.Services;
using ApiTest.Desktop.ViewModels;
using ApiTest.Desktop.ViewModels.Pages;
using ApiTest.Desktop.ViewModels.Windows;
using ApiTest.Desktop.Views.Pages;
using ApiTest.Desktop.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Threading;
using Wpf.Ui;

namespace ApiTest.Desktop
{
    public partial class App : Application
    {
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();

                // Page resolver service
                services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                services.AddSingleton<INavigationWindow, MainWindow>();
                services.AddSingleton<MainWindowViewModel>();

                services.AddSingleton<AddTestPage>();
                services.AddSingleton<AddTestPageViewModel>();
                services.AddSingleton<DashboardPage>();
                services.AddSingleton<DashboardViewModel>();
                services.AddSingleton<DataPage>();
                services.AddSingleton<DataViewModel>();
                services.AddSingleton<SettingsPage>();
                services.AddSingleton<SettingsViewModel>();

                // LiteDB service
                services.AddSingleton(new LiteDbCacheService("filename=cacheData.db;mode=shared"));
            })
            .Build();

        public static T GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Handle unhandled exceptions here
        }
    }
}
