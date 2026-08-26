using CryptoPortfolioTrackerWallet.Core.Models;
using CryptoPortfolioTrackerWallet.Core.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace CryptoPortfolioTrackerWallet.Tests
{
    public class TrackerServiceTests
    {
        private readonly TrackerService _trackerService;

        public TrackerServiceTests()
        {
            var provider = new SimulatedPriceProvider(NullLogger<SimulatedPriceProvider>.Instance);
            var storage = new InMemoryStorageProvider();
            var alerts = new ThresholdAlertEngine();
            _trackerService = new TrackerService(provider, storage, alerts, NullLogger<TrackerService>.Instance);
        }

        [Fact]
        public async Task AddAsset_IncreasesAssetCount()
        {
            await _trackerService.AddAssetAsync("BTC", "Bitcoin", 1.0);
            var portfolio = await _trackerService.GetPortfolioAsync();
            Assert.Single(portfolio.Assets);
        }

        [Fact]
        public async Task RefreshPrices_GeneratesSnapshots()
        {
            await _trackerService.AddAssetAsync("ETH", "Ethereum", 2.0);
            await _trackerService.RefreshPricesAsync();
            var portfolio = await _trackerService.GetPortfolioAsync();
            Assert.Single(portfolio.Snapshots);
        }

        [Fact]
        public async Task EvaluateAlerts_ThrowsNotImplementedException()
        {
            await Assert.ThrowsAsync<NotImplementedException>(() => _trackerService.EvaluateAlertsAsync());
        }
    }
}
