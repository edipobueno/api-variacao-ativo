using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Quote
{
    [JsonPropertyName("close")] public List<decimal?> Close { get; set; }

    [JsonPropertyName("low")] public List<decimal?> Low { get; set; }

    [JsonPropertyName("open")] public List<decimal?> Open { get; set; }

    [JsonPropertyName("high")] public List<decimal?> High { get; set; }

    [JsonPropertyName("volume")] public List<int?> Volume { get; set; }
}