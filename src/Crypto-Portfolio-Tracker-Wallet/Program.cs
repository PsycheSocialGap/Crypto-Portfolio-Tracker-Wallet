using CryptoPortfolioTrackerWallet.Core.Configuration;
using CryptoPortfolioTrackerWallet.Core.Services;
using CryptoPortfolioTrackerWallet.Core.Utils;
using CryptoPortfolioTrackerWallet.Infrastructure.Configuration;
using CryptoPortfolioTrackerWallet.Infrastructure.ConsoleUi;
using CryptoPortfolioTrackerWallet.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CryptoPortfolioTrackerWallet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "CryptoPortfolioTrackerWallet";
            var arguments = ArgumentParser.Parse(args);
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            var trackerService = serviceProvider.GetRequiredService<ITrackerService>();
            var healthChecker = serviceProvider.GetRequiredService<IHealthChecker>();
            var menuRenderer = serviceProvider.GetRequiredService<MenuRenderer>();

            logger.LogInformation("Console tracker module started");
            logger.LogInformation("Loading configuration and registering services...");
            await healthChecker.CheckAsync(CancellationToken.None);
            PrintBanner();
            await RunInteractiveLoop(trackerService, menuRenderer, logger, CancellationToken.None);
        }

        static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = ConfigurationLoader.Build(Array.Empty<string>());
            services.AddSingleton(configuration);
            services.AddSingleton(configuration.BindTrackerOptions());
            services.AddLogging(builder => builder.AddProvider(new ConsoleLoggerProvider()));
            services.AddSingleton<IPriceProvider, SimulatedPriceProvider>();
            services.AddSingleton<IStorageProvider, InMemoryStorageProvider>();
            services.AddSingleton<IAlertEngine, ThresholdAlertEngine>();
            services.AddSingleton<IHealthChecker, EndpointHealthChecker>();
            services.AddSingleton<MenuRenderer>();
            services.AddSingleton<ITrackerService, TrackerService>();
            return services;
        }

        static void PrintBanner()
        {
            System.Console.WriteLine("Tracker module initialized.");
        }

        static async Task RunInteractiveLoop(ITrackerService trackerService, MenuRenderer menuRenderer, ILogger logger, CancellationToken cancellationToken)
        {
            var menuOptions = new[]
            {
                "Add tracked asset",
                "Refresh prices",
                "Show portfolio snapshot",
                "Configure alert",
                "Check endpoint health",
                "Exit"
            };
            while (true)
            {
                menuRenderer.RenderHeader("CryptoPortfolioTrackerWallet - Console Tracker Module");
                menuRenderer.RenderMenu(menuOptions);
                var choice = System.Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        System.Console.Write("Symbol: ");
                        var symbol = System.Console.ReadLine() ?? "BTC";
                        System.Console.Write("Name: ");
                        var assetName = System.Console.ReadLine() ?? "Bitcoin";
                        System.Console.Write("Quantity: ");
                        var quantityText = System.Console.ReadLine() ?? "0";
                        double.TryParse(quantityText, out var quantity);
                        await trackerService.AddAssetAsync(symbol, assetName, quantity, cancellationToken);
                        break;
                    case "2":
                        await trackerService.RefreshPricesAsync(cancellationToken);
                        break;
                    case "3":
                        var portfolio = await trackerService.GetPortfolioAsync(cancellationToken);
                        System.Console.WriteLine($"Assets: {portfolio.Assets.Count}, Snapshots: {portfolio.Snapshots.Count}");
                        break;
                    case "4":
                        logger.LogWarning("Alert configuration is not implemented in this demo");
                        break;
                    case "5":
                        await trackerService.RefreshPricesAsync(cancellationToken);
                        break;
                    case "6":
                        return;
                    default:
                        logger.LogWarning("Invalid choice");
                        break;
                }
            }
        }
    }
}
