using MassTransit;
using VariacaoAtivo.Infra.MassTransit.Interfaces;

namespace VariacaoAtivo.Infra.MassTransit;

public abstract class MediatorEvent<I> : IMediatorEvent<I>
    where I : class
{
    public async Task Consume(ConsumeContext<I> context)
    {
        await Consume(context.Message);
    }

    public abstract Task Consume(I input);
}