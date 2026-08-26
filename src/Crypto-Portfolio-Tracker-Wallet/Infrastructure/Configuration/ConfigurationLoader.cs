using Microsoft.Extensions.Configuration;
using CryptoPortfolioTrackerWallet.Core.Configuration;

namespace CryptoPortfolioTrackerWallet.Infrastructure.Configuration
{
    public static class ConfigurationLoader
    {
        public static IConfiguration Build(string[] args)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables("TRACKER_")
                .Build();
        }

        public static TrackerOptions BindTrackerOptions(this IConfiguration configuration)
        {
            var options = new TrackerOptions();
            configuration.GetSection("Tracker").Bind(options);
            return options;
        }
    }
}
