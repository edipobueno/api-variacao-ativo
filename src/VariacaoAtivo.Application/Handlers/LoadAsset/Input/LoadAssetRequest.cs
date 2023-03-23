using Microsoft.AspNetCore.Mvc;

namespace VariacaoAtivo.Application.Chart.Handlers.LoadAsset;

public record LoadAssetRequest
{
    [FromBody] public string Symbol { get; set; }
}