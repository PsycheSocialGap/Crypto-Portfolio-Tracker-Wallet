using CryptoPortfolioTrackerWallet.Core.Models;
using CryptoPortfolioTrackerWallet.Core.Exceptions;
using Microsoft.Extensions.Logging;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public class TrackerService : ITrackerService
    {
        private readonly IPriceProvider _priceProvider;
        private readonly IStorageProvider _storageProvider;
        private readonly IAlertEngine _alertEngine;
        private readonly ILogger<TrackerService> _logger;
        private readonly double _threshold;

        public TrackerService(
            IPriceProvider priceProvider,
            IStorageProvider storageProvider,
            IAlertEngine alertEngine,
            ILogger<TrackerService> logger)
        {
            _priceProvider = priceProvider ?? throw new ArgumentNullException(nameof(priceProvider));
            _storageProvider = storageProvider ?? throw new ArgumentNullException(nameof(storageProvider));
            _alertEngine = alertEngine ?? throw new ArgumentNullException(nameof(alertEngine));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _threshold = 0.05;
        }

        public async Task AddAssetAsync(string symbol, string name, double quantity, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentException("Symbol required", nameof(symbol));
            var asset = new TrackedAsset { Symbol = symbol, Name = name, Quantity = quantity };
            await _storageProvider.SaveAssetAsync(asset, cancellationToken);
            _logger.LogInformation("Added {Symbol} ({Name}) with quantity {Quantity}", symbol, name, quantity);
        }

        public async Task<Portfolio> GetPortfolioAsync(CancellationToken cancellationToken = default)
        {
            var assets = await _storageProvider.GetAssetsAsync(cancellationToken);
            var snapshots = await _storageProvider.GetSnapshotsAsync(cancellationToken);
            return new Portfolio { Assets = assets, Snapshots = snapshots };
        }

        public async Task RefreshPricesAsync(CancellationToken cancellationToken = default)
        {
            var assets = await _storageProvider.GetAssetsAsync(cancellationToken);
            var previous = await _storageProvider.GetSnapshotsAsync(cancellationToken);
            var current = new List<PriceSnapshot>();
            foreach (var asset in assets)
            {
                try
                {
                    var snapshot = await _priceProvider.GetPriceAsync(asset.Symbol, "USD", cancellationToken);
                    await _storageProvider.SaveSnapshotAsync(snapshot, cancellationToken);
                    current.Add(snapshot);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to refresh price for {Symbol}", asset.Symbol);
                }
            }
            var alerts = _alertEngine.Evaluate(current, previous, _threshold);
            foreach (var alert in alerts)
            {
                _logger.LogWarning("[ALERT] {Symbol}: {Message}", alert.Symbol, alert.Message);
            }
        }

        public async Task<List<Alert>> EvaluateAlertsAsync(CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException("Alert evaluation is integrated into RefreshPricesAsync");
        }
    }
}
