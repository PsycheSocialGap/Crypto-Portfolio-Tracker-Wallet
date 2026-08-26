using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public class ThresholdAlertEngine : IAlertEngine
    {
        public List<Alert> Evaluate(List<PriceSnapshot> current, List<PriceSnapshot> previous, double threshold)
        {
            var alerts = new List<Alert>();
            foreach (var snap in current)
            {
                var prev = previous.FirstOrDefault(p => p.Symbol.Equals(snap.Symbol, StringComparison.OrdinalIgnoreCase) && p.Currency.Equals(snap.Currency, StringComparison.OrdinalIgnoreCase));
                if (prev == null) continue;
                var change = Math.Abs(snap.Price - prev.Price) / prev.Price;
                if (change > threshold)
                {
                    var direction = snap.Price > prev.Price ? "up" : "down";
                    alerts.Add(new Alert
                    {
                        Symbol = snap.Symbol,
                        Message = $"Price moved {direction} by {change:P2} from {prev.Price} to {snap.Price}",
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }
            return alerts;
        }
    }
}
