using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public interface ITrackerService
    {
        Task AddAssetAsync(string symbol, string name, double quantity, CancellationToken cancellationToken = default);
        Task<Portfolio> GetPortfolioAsync(CancellationToken cancellationToken = default);
        Task RefreshPricesAsync(CancellationToken cancellationToken = default);
        Task<List<Alert>> EvaluateAlertsAsync(CancellationToken cancellationToken = default);
    }
}
