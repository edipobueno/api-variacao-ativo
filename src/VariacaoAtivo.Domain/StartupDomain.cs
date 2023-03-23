using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Domain.Repositories;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit.Startup;

namespace VariacaoAtivo.Domain;

public static class StartupDomain
{
    public static void AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMtMediator(configuration);
        services.AddYahooProvider(configuration);

        services.AddTransient<IBaseCollection<Asset>>(cfg => new AssetRepository(configuration["mongo-va-cs"]));
    }
}