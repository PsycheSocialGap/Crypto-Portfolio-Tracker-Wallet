# Crypto-Portfolio-Tracker-Wallet

<p align="center">
  <img src="https://img.shields.io/badge/C%23-10.0-239120?style=for-the-badge&logo=csharp" alt="C# 10.0">
  <img src="https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet" alt=".NET 10">
  <img src="https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-0078D4?style=for-the-badge" alt="Platform">
</p>

<p align="center">
  <img src="https://img.shields.io/badge/build-passing-brightgreen?style=flat-square" alt="Build">
  <img src="https://img.shields.io/badge/tests-xUnit-6C4AB6?style=flat-square" alt="Tests">
  <img src="https://img.shields.io/badge/CI-GitHub%20Actions-2088FF?style=flat-square&logo=githubactions" alt="CI">
  <img src="https://img.shields.io/badge/license-MIT-green?style=flat-square" alt="License">
</p>

<h2 align="center">A modular console cryptocurrency portfolio manager</h2>

<p align="center">
  <strong>Crypto-Portfolio-Tracker-Wallet</strong> is a research-oriented, educational console module designed for developers, analysts, and blockchain enthusiasts who need a structured, extensible foundation for tracking, monitoring, and reacting to portfolio data.
</p>

---

## Why Crypto-Portfolio-Tracker-Wallet?

Most monitoring tools are either heavyweight dashboards, closed SaaS products, or unstructured scripts. Crypto-Portfolio-Tracker-Wallet bridges the gap by offering:

- A **clean, layered architecture** inspired by enterprise .NET applications.
- **Dependency injection**, structured logging, and configuration-driven behavior.
- **Comprehensive separation of concerns**: domain logic lives in `Core`, while logging, configuration, and UI live in `Infrastructure`.
- **A built-in test suite** to validate providers, alerting, and orchestration.
- **CI/CD pipeline** ready to run on every push and pull request.

Whether you are building a custom tracker, prototyping a trading signal pipeline, or teaching data aggregation patterns, Crypto-Portfolio-Tracker-Wallet gives you a credible, maintainable starting point.

## Features

| Feature | Description |
|---------|-------------|
| **Multi-source data providers** | Fetch portfolio data from simulated JSON-RPC and REST endpoints. |
| **In-memory storage** | Thread-safe repository for snapshots and alerts. |
| **Alert engine** | Configure thresholds and emit console notifications. |
| **Health checks** | Verify configured endpoints before running operations. |
| **Configuration-driven** | JSON and environment-variable configuration support. |
| **Structured logging** | Color-coded console logs with Microsoft.Extensions.Logging. |
| **xUnit test suite** | Unit tests covering providers, alerts, and core orchestration. |
| **GitHub Actions CI** | Automated build and test pipeline on Windows runners. |

## Architecture

```
Crypto-Portfolio-Tracker-Wallet
├── src/Crypto-Portfolio-Tracker-Wallet
│   ├── Core
│   │   ├── Configuration       # TrackerOptions
│   │   ├── Models              # TrackedAsset, Snapshot, Alert, Portfolio
│   │   ├── Services            # ITrackerService, IPriceProvider, IAlertEngine
│   │   ├── Utils               # ValidationUtils, ArgumentParser
│   │   └── Exceptions          # TrackerException hierarchy
│   └── Infrastructure
│       ├── Configuration       # ConfigurationLoader
│       ├── ConsoleUi           # MenuRenderer
│       └── Logging             # ConsoleLogger
├── tests/Crypto-Portfolio-Tracker-Wallet.Tests          # xUnit tests
├── config                      # appsettings.json
├── docs                        # architecture, security, api, development
└── scripts                     # build.ps1, run.ps1
```

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later
- A local or remote portfolio endpoint (optional for offline demos)

### Installation

```bash
# Clone the repository
git clone https://github.com/yourusername/Crypto-Portfolio-Tracker-Wallet.git
cd Crypto-Portfolio-Tracker-Wallet

# Restore and build
dotnet restore Crypto-Portfolio-Tracker-Wallet.sln
dotnet build Crypto-Portfolio-Tracker-Wallet.sln

# Run tests
dotnet test Crypto-Portfolio-Tracker-Wallet.sln
```

### Interactive Usage

```bash
# Run in interactive mode
dotnet run --project src/Crypto-Portfolio-Tracker-Wallet/Crypto-Portfolio-Tracker-Wallet.csproj

# Or use the provided helper
scripts/run.ps1
```

### Example Session

```
  ╔══════════════════════════════════════════════════════════╗
  ║              Crypto-Portfolio-Tracker-Wallet - Console Tracker Module              ║
  ║        Educational simulation for portfolio research      ║
  ╚══════════════════════════════════════════════════════════╝

Select an option:
  1. Add tracked asset
  2. Refresh prices
  3. Show portfolio snapshot
  4. Configure alert
  5. Check endpoint health
  6. Exit
> 1
[2026-08-24 22:00:00] [Information] Added BTC at 42000.00 USD
```

## Configuration

Edit `config/appsettings.json`:

```json
{
  "Tracker": {
    "RefreshIntervalMs": 30000,
    "DefaultCurrency": "USD",
    "PriceEndpoint": "https://api.example.com/prices",
    "AlertThreshold": 0.05
  }
}
```

Environment variables prefixed with `TRACKER_` are also supported.

## Roadmap

- [ ] Persistent storage provider (SQLite / JSON file)
- [ ] Historical chart data export
- [ ] Webhook / email notification adapter
- [ ] Multi-currency support
- [ ] Plugin system for custom providers

## Documentation

- [Architecture](docs/architecture.md)
- [Security & Threat Model](docs/security.md)
- [Development Guide](docs/development.md)
- [API Reference](docs/api.md)

## Contributing

We welcome contributions. Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines, code style, and the pull-request process.

## Support

If you find this project useful, consider giving it a star on GitHub. For questions and discussions, open an issue or start a discussion thread.

## License

Crypto-Portfolio-Tracker-Wallet is released under the MIT License. See [LICENSE](LICENSE) for details.

---

<p align="center">
  Built with .NET 10 for researchers, developers, and blockchain enthusiasts.
</p>


## Performance & Extensibility

Crypto-Portfolio-Tracker-Wallet is built for clarity and extension:

- **No real network calls** by default — all simulations run locally.
- **Provider pattern** makes swapping in real adapters straightforward.
- **JSON persistence** layer for caching simulated results.
- **Metrics publisher** ready for console, Prometheus, or cloud sinks.
- **Background service** template for periodic polling tasks.
- **Domain events** and **pipeline behaviors** for cross-cutting concerns.
- **xUnit test suite** with core and additional integration-style tests.

## Sample Data

A sample dataset is included in `data/samples.json` to demonstrate the expected input/output shape for the domain workflows.

## FAQ

See [docs/faq.md](docs/faq.md) for common questions.

## Usage

See [docs/usage.md](docs/usage.md) for detailed usage instructions.
