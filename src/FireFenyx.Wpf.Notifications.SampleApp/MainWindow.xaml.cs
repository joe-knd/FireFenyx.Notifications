using FireFenyx.Notifications.SampleApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FireFenyx.Wpf.Notifications.SampleApp;

/// <summary>
/// Main window for the WPF notification sample application.
/// </summary>
public partial class MainWindow : Window
{
    public MainViewModel ViewModel { get; }

    public MainWindow()
    {
        InitializeComponent();
        ViewModel = App.Services.GetRequiredService<MainViewModel>()!;
        DataContext = ViewModel;
    }
}
