using CryptoPortfolioTrackerWallet.Core.Models;
using Microsoft.Extensions.Logging;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public class SimulatedPriceProvider : IPriceProvider
    {
        private readonly ILogger<SimulatedPriceProvider> _logger;
        private readonly Random _random = new();

        public SimulatedPriceProvider(ILogger<SimulatedPriceProvider> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<PriceSnapshot> GetPriceAsync(string symbol, string currency, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Fetching simulated price for {Symbol} in {Currency}", symbol, currency);
            var price = 1000 + _random.NextDouble() * 50000;
            return Task.FromResult(new PriceSnapshot
            {
                Symbol = symbol,
                Currency = currency,
                Price = Math.Round(price, 2),
                CapturedAt = DateTime.UtcNow
            });
        }
    }
}
