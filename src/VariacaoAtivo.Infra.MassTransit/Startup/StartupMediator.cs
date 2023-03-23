using MassTransit;
using MassTransit.Internals;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VariacaoAtivo.Infra.MassTransit.Interfaces;

namespace VariacaoAtivo.Infra.MassTransit.Startup;

public static class StartupMediator
{
    public static void AddMtMediator(this IServiceCollection services, IConfiguration configuration)
    {
        var handlers =
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetTypes()
            where
                (type.HasInterface(typeof(IMediatorCommand<,>)) || type.HasInterface(typeof(IMediatorEvent<>))) && type.IsAbstract is false
            select type;

        services.AddMediator(cfg =>
        {
            foreach (var type in handlers)
            {
                cfg.AddConsumer(type);
            }
        });
    }
}