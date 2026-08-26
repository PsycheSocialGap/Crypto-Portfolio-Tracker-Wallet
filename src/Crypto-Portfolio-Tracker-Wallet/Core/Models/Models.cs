namespace CryptoPortfolioTrackerWallet.Core.Models
{
    public class TrackedAsset
    {
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
    }

    public class PriceSnapshot
    {
        public string Symbol { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CapturedAt { get; set; } = DateTime.UtcNow;
    }

    public class Alert
    {
        public string Symbol { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class Portfolio
    {
        public List<TrackedAsset> Assets { get; set; } = new();
        public List<PriceSnapshot> Snapshots { get; set; } = new();
    }
}
