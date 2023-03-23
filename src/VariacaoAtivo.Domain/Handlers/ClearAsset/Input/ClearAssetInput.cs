using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Domain.Handlers.ClearAsset.Input;

public record ClearAssetInput
{
    public string Symbol { get; init; }
}