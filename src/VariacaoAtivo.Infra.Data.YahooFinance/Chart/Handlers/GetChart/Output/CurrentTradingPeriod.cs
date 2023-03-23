using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class CurrentTradingPeriod
{
    [JsonPropertyName("pre")] public Pre Pre { get; set; }

    [JsonPropertyName("regular")] public Regular Regular { get; set; }

    [JsonPropertyName("post")] public Post Post { get; set; }
}