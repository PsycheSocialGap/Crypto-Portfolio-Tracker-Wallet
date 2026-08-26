# API Reference

This module exposes the following public service interfaces:

- `ITrackerService` - orchestrates refresh and alert logic.
- `IPriceProvider` - abstraction for data sources.
- `IStorageProvider` - in-memory storage of tracked assets.
- `IAlertEngine` - threshold evaluation and notifications.

For internal usage, see the unit tests and `Program.cs`.
