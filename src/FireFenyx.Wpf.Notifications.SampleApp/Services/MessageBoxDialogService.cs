using System;
using System.Threading.Tasks;
using System.Windows;

namespace FireFenyx.Wpf.Notifications.SampleApp.Services;

public sealed class MessageBoxDialogService(Func<Window?> windowAccessor) : IDialogService
{
    public Task<bool> ConfirmAsync(string title, string message, string confirmText = "Yes", string cancelText = "No")
    {
        var owner = windowAccessor();
        var result = owner is not null
            ? MessageBox.Show(owner, message, title, MessageBoxButton.YesNo, MessageBoxImage.Question)
            : MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);

        return Task.FromResult(result == MessageBoxResult.Yes);
    }
}
