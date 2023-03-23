namespace VariacaoAtivo.Application.Handlers.GetQuotation.Input;

public record GetQuotationRequest
{
    public string Symbol { get; set; }
    public bool WithVariations { get; set; }
    public DateTime? StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
}