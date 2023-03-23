using MassTransit;

namespace VariacaoAtivo.Infra.MassTransit.Interfaces;

public interface IMediatorEvent<I> : IConsumer<I>
    where I : class
{
}