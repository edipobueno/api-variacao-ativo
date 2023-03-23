using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Indicators
{
    [JsonPropertyName("quote")] public List<Quote> Quote { get; set; }
}