using CryptoPortfolioTrackerWallet.Core.Models;

namespace CryptoPortfolioTrackerWallet.Core.Services
{
    public interface IAlertEngine
    {
        List<Alert> Evaluate(List<PriceSnapshot> current, List<PriceSnapshot> previous, double threshold);
    }
}
