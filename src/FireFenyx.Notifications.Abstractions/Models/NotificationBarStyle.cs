namespace FireFenyx.Notifications.Models;

/// <summary>
/// Controls the visual appearance of notification bars.
/// </summary>
public enum NotificationBarStyle
{
    /// <summary>
    /// Displays a colored accent strip along the leading edge with a material background.
    /// </summary>
    AccentStrip,

    /// <summary>
    /// Uses the Fluent design language with a severity-colored background, similar to the WinUI InfoBar.
    /// </summary>
    Fluent
}
