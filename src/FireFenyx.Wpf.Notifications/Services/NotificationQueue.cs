using FireFenyx.Wpf.Notifications.Models;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FireFenyx.Wpf.Notifications.Services;

/// <summary>
/// Default implementation of <see cref="INotificationQueue"/> based on <see cref="Channel{T}"/>.
/// </summary>
public sealed class NotificationQueue : INotificationQueue
{
    private readonly Channel<NotificationRequest> _channel =
        Channel.CreateUnbounded<NotificationRequest>();

    private Func<NotificationRequest, Task>? _processor;
    private readonly Dispatcher? _dispatcher;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationQueue"/> class.
    /// </summary>
    public NotificationQueue()
    {
        // Resolving this service should happen on the UI thread in typical WPF apps.
        // If we have a Dispatcher, we can always marshal UI work back correctly.
        _dispatcher = Dispatcher.CurrentDispatcher;
        Task.Run(ProcessLoopAsync);
    }

    /// <inheritdoc />
    public void SetProcessor(Func<NotificationRequest, Task> processor)
        => _processor = processor;

    /// <inheritdoc />
    public void Enqueue(NotificationRequest request)
        => _channel.Writer.TryWrite(request);

    private static Task EnqueueOnDispatcherAsync(Dispatcher dispatcher, Func<Task> action)
    {
        var tcs = new TaskCompletionSource<object?>(TaskCreationOptions.RunContinuationsAsynchronously);

        dispatcher.InvokeAsync(async () =>
        {
            try
            {
                await action().ConfigureAwait(true);
                tcs.TrySetResult(null);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }
        });

        return tcs.Task;
    }

    private async Task ProcessLoopAsync()
    {
        await foreach (var request in _channel.Reader.ReadAllAsync())
        {
            if (_processor is not null)
            {
                if (_dispatcher is null || _dispatcher.CheckAccess())
                {
                    await _processor(request);
                }
                else
                {
                    await EnqueueOnDispatcherAsync(_dispatcher, () => _processor(request)).ConfigureAwait(false);
                }
            }
        }
    }
}
