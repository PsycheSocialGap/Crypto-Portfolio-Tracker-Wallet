using CryptoPortfolioTrackerWallet.Core.Events;
using CryptoPortfolioTrackerWallet.Core.Pipelines;
using CryptoPortfolioTrackerWallet.Infrastructure.Events;
using CryptoPortfolioTrackerWallet.Infrastructure.Metrics;
using CryptoPortfolioTrackerWallet.Infrastructure.Persistence;
using CryptoPortfolioTrackerWallet.Infrastructure.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoPortfolioTrackerWallet.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IJsonRepository<>), typeof(JsonRepository<>));
            services.AddSingleton<IRequestValidator<object>, DefaultRequestValidator<object>>();
            services.AddSingleton<IMetricsPublisher, ConsoleMetricsPublisher>();
            services.AddSingleton<IDomainEventBus, InMemoryDomainEventBus>();
            services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            return services;
        }
    }
}
