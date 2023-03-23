using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class GetChartOutput
{
    [JsonPropertyName("chart")] public Chart Chart { get; set; }
}