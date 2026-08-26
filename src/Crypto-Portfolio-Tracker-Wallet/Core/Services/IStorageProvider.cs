using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public interface IStorageProvider
    {
        Task SaveAssetAsync(TrackedAsset asset, CancellationToken cancellationToken = default);
        Task<List<TrackedAsset>> GetAssetsAsync(CancellationToken cancellationToken = default);
        Task SaveSnapshotAsync(PriceSnapshot snapshot, CancellationToken cancellationToken = default);
        Task<List<PriceSnapshot>> GetSnapshotsAsync(CancellationToken cancellationToken = default);
    }
}
