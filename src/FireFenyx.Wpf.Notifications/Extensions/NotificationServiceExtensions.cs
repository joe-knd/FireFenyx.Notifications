using FireFenyx.Notifications.Services;
using FireFenyx.Wpf.Notifications.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FireFenyx.Wpf.Notifications.Extensions;

/// <summary>
/// Extension methods for registering FireFenyx notification services.
/// </summary>
public static class NotificationServiceExtensions
{
    /// <summary>
    /// Registers the notification queue and service into the provided DI container.
    /// The queue singleton is created eagerly so that <see cref="Controls.NotificationHost"/>
    /// can auto-connect without explicit XAML wiring.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The same service collection for chaining.</returns>
    public static IServiceCollection AddNotificationServices(this IServiceCollection services)
    {
        var queue = new NotificationQueue();
        NotificationDefaults.Queue = queue;
        services.AddSingleton<INotificationQueue>(queue);
        services.AddSingleton<INotificationService, NotificationService>();
        return services;
    }
}
