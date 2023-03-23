namespace VariacaoAtivo.Domain.Handlers.GetQuotation.Input;

public record GetQuotationInput
{
    public string Symbol { get; init; }
    public DateTime QuotationsStartsAt { get; set; }
    public DateTime QuotationsEndsAt { get; set; }
}