namespace FireFenyx.Wpf.Notifications.Models;

/// <summary>
/// Defines the background material used when rendering a notification.
/// </summary>
public enum NotificationMaterial
{
    /// <summary>
    /// Solid color background.
    /// </summary>
    Solid,

    /// <summary>
    /// Acrylic-style background (rendered as a semi-transparent solid in WPF).
    /// </summary>
    Acrylic,

    /// <summary>
    /// Mica-style background (rendered as a solid color in WPF).
    /// </summary>
    Mica
}
