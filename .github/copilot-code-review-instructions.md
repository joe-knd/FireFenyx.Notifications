# Code Review Instructions

## General
- All public APIs must have XML doc comments.
- Use `init` properties on model classes.
- Prefer collection expressions (`[]`) over `new List<T>()`.
- Use file-scoped namespaces.
- Use primary constructors where appropriate.

## Async
- All async methods must use `ConfigureAwait` appropriately.
- Avoid `async void` except in event handlers.

## Architecture
- WPF and WinUI controls should follow the same public API surface.
- Shared abstractions must target plain `net10.0` with no UI dependencies.
- Platform-specific code belongs in the WPF or WinUI project, never in Abstractions.

## Tests
- Every public method on `NotificationService`, `IProgressNotification`, and `IPersistentNotification` must have at least one unit test.
- Use xUnit `[Fact]` for single-case tests and `[Theory]` for parameterized tests.
- Test classes should be `sealed`.
