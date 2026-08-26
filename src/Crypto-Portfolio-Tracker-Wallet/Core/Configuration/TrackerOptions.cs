namespace CryptoPortfolioTrackerWallet.Core.Configuration
{
    public class TrackerOptions
    {
        public int RefreshIntervalMs { get; set; } = 30000;
        public string DefaultCurrency { get; set; } = "USD";
        public string PriceEndpoint { get; set; } = "https://api.example.com/prices";
        public double AlertThreshold { get; set; } = 0.05;
    }
}
