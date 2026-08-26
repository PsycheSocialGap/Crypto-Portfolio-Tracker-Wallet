# Development Guide

## Building

```bash
dotnet build
```

## Testing

```bash
dotnet test
```

## Adding a new provider

1. Implement `IPriceProvider` in `Core/Services`.
2. Register it in `Program.cs`.
3. Add unit tests in `tests/ProjectName.Tests`.
