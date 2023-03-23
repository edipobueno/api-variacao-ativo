using MassTransit;
using MassTransit.Mediator;

namespace VariacaoAtivo.Infra.MassTransit.Extensions;

public static class MediatorExtensions
{
    public static async ValueTask<Response<TO>> GetResponse<T, TO>(this IMediator mediator, T input)
        where T : class
        where TO : class
    {
        return await mediator.CreateRequestClient<T>().GetResponse<TO>(input);
    }
}