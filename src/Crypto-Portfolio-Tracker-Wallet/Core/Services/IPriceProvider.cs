using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public interface IPriceProvider
    {
        Task<PriceSnapshot> GetPriceAsync(string symbol, string currency, CancellationToken cancellationToken = default);
    }
}
