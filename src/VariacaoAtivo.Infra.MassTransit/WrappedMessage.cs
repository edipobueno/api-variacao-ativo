namespace VariacaoAtivo.Infra.MassTransit;

public class WrappedMessage<T>
{
    public T Value { get; }

    public WrappedMessage(T value)
    {
        Value = value;
    }
}