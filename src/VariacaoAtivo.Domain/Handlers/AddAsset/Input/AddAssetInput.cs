using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Domain.Handlers.AddAsset.Input;

public record AddAssetInput
{
    public Asset Asset { get; init; }
}