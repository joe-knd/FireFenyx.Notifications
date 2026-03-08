using FireFenyx.Wpf.Notifications.Extensions;
using FireFenyx.Notifications.SampleApp.Services;
using FireFenyx.Notifications.SampleApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FireFenyx.Wpf.Notifications.SampleApp;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    public static IServiceProvider Services { get; private set; } = default!;

    public static Window? MainAppWindow { get; private set; }

    public App()
    {
        ConfigureServices();
    }

    private void ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register your notification library
        services.AddNotificationServices();

        // Register ViewModels
        services.AddSingleton<MainViewModel>();

        // UI services
        services.AddSingleton<IDialogService>(_ => new Services.MessageBoxDialogService(() => MainAppWindow));

        Services = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var window = new MainWindow();
        MainAppWindow = window;
        window.Show();
    }
}
