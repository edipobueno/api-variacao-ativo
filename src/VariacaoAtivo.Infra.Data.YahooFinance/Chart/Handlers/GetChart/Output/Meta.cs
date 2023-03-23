using System.Text.Json.Serialization;

namespace VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;

public class Meta
{
    [JsonPropertyName("currency")] public string Currency { get; set; }

    [JsonPropertyName("symbol")] public string Symbol { get; set; }

    [JsonPropertyName("exchangeName")] public string ExchangeName { get; set; }

    [JsonPropertyName("instrumentType")] public string InstrumentType { get; set; }

    [JsonPropertyName("firstTradeDate")] public long FirstTradeDate { get; set; }

    [JsonPropertyName("regularMarketTime")]
    public long RegularMarketTime { get; set; }

    [JsonPropertyName("gmtoffset")] public long Gmtoffset { get; set; }

    [JsonPropertyName("timezone")] public string Timezone { get; set; }

    [JsonPropertyName("exchangeTimezoneName")]
    public string ExchangeTimezoneName { get; set; }

    [JsonPropertyName("regularMarketPrice")]
    public double RegularMarketPrice { get; set; }

    [JsonPropertyName("chartPreviousClose")]
    public double ChartPreviousClose { get; set; }

    [JsonPropertyName("previousClose")] public double PreviousClose { get; set; }

    [JsonPropertyName("scale")] public int Scale { get; set; }

    [JsonPropertyName("priceHint")] public int PriceHint { get; set; }

    [JsonPropertyName("currentTradingPeriod")]
    public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

    [JsonPropertyName("tradingPeriods")] public List<List<object>> TradingPeriods { get; set; }

    [JsonPropertyName("dataGranularity")] public string DataGranularity { get; set; }

    [JsonPropertyName("range")] public string Range { get; set; }

    [JsonPropertyName("validRanges")] public List<string> ValidRanges { get; set; }
}