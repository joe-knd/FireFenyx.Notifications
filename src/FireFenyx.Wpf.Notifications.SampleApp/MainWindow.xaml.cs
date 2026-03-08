using FireFenyx.Wpf.Notifications.SampleApp.ViewModels;
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

    private void Success_Click(object sender, RoutedEventArgs e)
        => ViewModel.ShowSuccess();

    private void Warning_Click(object sender, RoutedEventArgs e)
        => ViewModel.ShowWarning();

    private void Error_Click(object sender, RoutedEventArgs e)
        => ViewModel.ShowError();

    private void Progress_Click(object sender, RoutedEventArgs e)
        => ViewModel.ShowProgress();

    private void SendFile_Click(object sender, RoutedEventArgs e)
        => ViewModel.SendFileComplexScenario();

    private void ShowPersistent_Click(object sender, RoutedEventArgs e)
        => ViewModel.ShowPersistentNoConnection();

    private void DismissPersistent_Click(object sender, RoutedEventArgs e)
        => ViewModel.DismissPersistent();
}
