using FireFenyx.Notifications.Services;

namespace FireFenyx.WinUI.Notifications.Services;

/// <summary>
/// Holds the default singleton <see cref="INotificationQueue"/> created during DI registration
/// so that <see cref="Controls.NotificationHost"/> can auto-connect without explicit XAML wiring.
/// </summary>
internal static class NotificationDefaults
{
    internal static INotificationQueue? Queue { get; set; }
}
