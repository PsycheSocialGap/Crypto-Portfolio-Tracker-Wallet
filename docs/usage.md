# Usage Guide

## Running Crypto-Portfolio-Tracker-Wallet

```bash
dotnet run --project src/Crypto-Portfolio-Tracker-Wallet/Crypto-Portfolio-Tracker-Wallet.csproj
```

## CLI Arguments

| Argument | Description |
|----------|-------------|
| `--config` | Path to a custom appsettings file. |
| `--verbose` | Enable verbose logging. |

## Sample Data

The `data/samples.json` file contains realistic-looking simulated data for local testing.

## Extending

Add new providers by implementing the domain interfaces in `Core/Services` and registering them in `Program.cs`.
