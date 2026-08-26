namespace CryptoPortfolioTrackerWallet.Core.Exceptions
{
    public class TrackerException : Exception
    {
        public TrackerException(string message) : base(message) { }
        public TrackerException(string message, Exception inner) : base(message, inner) { }
    }
}
