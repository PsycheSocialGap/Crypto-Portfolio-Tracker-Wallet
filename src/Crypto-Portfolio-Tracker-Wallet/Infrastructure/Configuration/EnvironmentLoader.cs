using Microsoft.Extensions.Configuration;

namespace CryptoPortfolioTrackerWallet.Infrastructure.Configuration
{
    public static class EnvironmentLoader
    {
        public static IConfigurationRoot Load(string[]? args = null)
        {
            return new ConfigurationBuilder()
                .AddEnvironmentVariables("PORTFOLIOMANAGER_")
                .AddCommandLine(args ?? Array.Empty<string>())
                .Build();
        }
    }
}
