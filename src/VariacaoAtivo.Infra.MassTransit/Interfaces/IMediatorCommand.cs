using MassTransit;

namespace VariacaoAtivo.Infra.MassTransit.Interfaces;

public interface IMediatorCommand<I, O> : IConsumer<I>
    where I : class
    where O : class
{
}