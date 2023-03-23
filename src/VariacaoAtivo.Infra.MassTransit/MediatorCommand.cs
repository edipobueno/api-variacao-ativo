using MassTransit;
using VariacaoAtivo.Infra.MassTransit.Interfaces;

namespace VariacaoAtivo.Infra.MassTransit;

public abstract class MediatorCommand<I, O> : IMediatorCommand<I, O>
    where I : class
    where O : class
{
    public async Task Consume(ConsumeContext<I> context)
    {
        var output = await Consume(context.Message);

        await context.RespondAsync(output);
    }

    public abstract ValueTask<O> Consume(I input);
}