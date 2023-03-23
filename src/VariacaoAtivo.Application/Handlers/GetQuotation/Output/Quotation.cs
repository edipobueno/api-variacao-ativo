namespace VariacaoAtivo.Application.Handlers.GetQuotation.Output;

public record Quotation
{
    public string Id { get; set; }
    public DateTime Day { get; set; }
    public decimal Close { get; set; }
    public decimal CloseVariation { get; set; }
    public decimal Open { get; set; }
    public decimal OpenVariation { get; set; }
    public decimal High { get; set; }
    public decimal HighVariation { get; set; }
    public decimal Low { get; set; }
    public decimal LowVariation { get; set; }
    public decimal Volume { get; set; }
    public decimal VolumeVariation { get; set; }
}