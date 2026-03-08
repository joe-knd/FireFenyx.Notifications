using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace FireFenyx.Wpf.Notifications.Extensions;

/// <summary>
/// Provides simple animation helpers for WPF elements.
/// </summary>
public static class AnimationExtensions
{
    /// <summary>
    /// Animates the Y translation of a <see cref="Transform"/>.
    /// </summary>
    /// <param name="transform">The transform to animate.</param>
    /// <param name="to">The target Y value.</param>
    /// <param name="durationMs">Animation duration in milliseconds.</param>
    /// <returns>A task that completes when the animation finishes.</returns>
    public static Task AnimateY(this Transform transform, double to, int durationMs)
    {
        if (transform is not TranslateTransform translateTransform)
            return Task.CompletedTask;

        var animation = new DoubleAnimation
        {
            To = to,
            Duration = TimeSpan.FromMilliseconds(durationMs),
            EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
        };

        var tcs = new TaskCompletionSource();
        animation.Completed += (_, _) => tcs.SetResult();
        translateTransform.BeginAnimation(TranslateTransform.YProperty, animation);
        return tcs.Task;
    }

    /// <summary>
    /// Animates the opacity of a <see cref="UIElement"/>.
    /// </summary>
    /// <param name="element">The element to animate.</param>
    /// <param name="to">The target opacity.</param>
    /// <param name="durationMs">Animation duration in milliseconds.</param>
    /// <returns>A task that completes when the animation finishes.</returns>
    public static Task Fade(this UIElement element, double to, int durationMs)
    {
        var animation = new DoubleAnimation
        {
            To = to,
            Duration = TimeSpan.FromMilliseconds(durationMs)
        };

        var tcs = new TaskCompletionSource();
        animation.Completed += (_, _) => tcs.SetResult();
        element.BeginAnimation(UIElement.OpacityProperty, animation);
        return tcs.Task;
    }

    /// <summary>
    /// Animates the scale of a <see cref="UIElement"/>.
    /// </summary>
    /// <param name="element">The element to animate.</param>
    /// <param name="to">The target scale value.</param>
    /// <param name="durationMs">Animation duration in milliseconds.</param>
    /// <returns>A task that completes when the animation finishes.</returns>
    public static Task Scale(this UIElement element, double to, int durationMs)
    {
        var transform = element.RenderTransform as ScaleTransform;
        if (transform is null)
        {
            transform = new ScaleTransform(0.8, 0.8);
            element.RenderTransform = transform;
            element.RenderTransformOrigin = new Point(0.5, 1);
        }

        var animX = new DoubleAnimation { To = to, Duration = TimeSpan.FromMilliseconds(durationMs) };
        var animY = new DoubleAnimation { To = to, Duration = TimeSpan.FromMilliseconds(durationMs) };

        var tcs = new TaskCompletionSource();
        animX.Completed += (_, _) => tcs.SetResult();

        transform.BeginAnimation(ScaleTransform.ScaleXProperty, animX);
        transform.BeginAnimation(ScaleTransform.ScaleYProperty, animY);

        return tcs.Task;
    }
}
