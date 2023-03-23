using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Result
{
    [JsonPropertyName("meta")] public Meta Meta { get; set; }

    [JsonPropertyName("timestamp")] public List<long> Timestamp { get; set; }

    [JsonPropertyName("indicators")] public Indicators Indicators { get; set; }
}