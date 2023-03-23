using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Chart
{
    [JsonPropertyName("result")] public List<Result> Result { get; set; }

    [JsonPropertyName("error")] public object Error { get; set; }
}