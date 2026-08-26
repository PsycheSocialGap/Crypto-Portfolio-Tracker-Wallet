using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public class InMemoryStorageProvider : IStorageProvider
    {
        private readonly List<TrackedAsset> _assets = new();
        private readonly List<PriceSnapshot> _snapshots = new();
        private readonly SemaphoreSlim _lock = new(1, 1);

        public async Task SaveAssetAsync(TrackedAsset asset, CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try
            {
                _assets.RemoveAll(a => a.Symbol.Equals(asset.Symbol, StringComparison.OrdinalIgnoreCase));
                _assets.Add(asset);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<List<TrackedAsset>> GetAssetsAsync(CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try
            {
                return _assets.ToList();
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task SaveSnapshotAsync(PriceSnapshot snapshot, CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try
            {
                _snapshots.RemoveAll(s => s.Symbol.Equals(snapshot.Symbol, StringComparison.OrdinalIgnoreCase) && s.Currency.Equals(snapshot.Currency, StringComparison.OrdinalIgnoreCase));
                _snapshots.Add(snapshot);
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task<List<PriceSnapshot>> GetSnapshotsAsync(CancellationToken cancellationToken = default)
        {
            await _lock.WaitAsync(cancellationToken);
            try
            {
                return _snapshots.ToList();
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
