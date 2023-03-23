using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Post
{
    [JsonPropertyName("timezone")] public string Timezone { get; set; }

    [JsonPropertyName("start")] public int Start { get; set; }

    [JsonPropertyName("end")] public int End { get; set; }

    [JsonPropertyName("gmtoffset")] public int Gmtoffset { get; set; }
}