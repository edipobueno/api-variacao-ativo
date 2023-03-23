using MassTransit;
using Microsoft.Extensions.Configuration;
using VariacaoAtivo.Infra.Data.YahooFinance;
using VariacaoAtivo.Infra.Data.YahooFinance.Startup;

namespace Microsoft.Extensions.DependencyInjection;

public static class StartupExtension
{
    public static void AddYahooProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.Configure<YahooFinanceConfiguration>(cfg =>
        {
            cfg.ChartUrl = configuration.GetSection("YahooFinanceConfiguration:ChartUrl").Value;
        });
    }
}