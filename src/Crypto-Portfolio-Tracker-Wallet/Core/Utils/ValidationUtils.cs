namespace CryptoPortfolioTrackerWallet.Core.Utils
{
    public static class ValidationUtils
    {
        public static bool IsValidSymbol(string symbol)
        {
            return !string.IsNullOrWhiteSpace(symbol) && symbol.Length <= 10;
        }

        public static bool IsPositiveQuantity(double quantity)
        {
            return quantity >= 0;
        }
    }
}
