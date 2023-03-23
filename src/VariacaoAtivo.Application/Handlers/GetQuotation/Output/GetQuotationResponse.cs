namespace VariacaoAtivo.Application.Handlers.GetQuotation.Output;

public record GetQuotationResponse
{
    public List<Quotation> Quotations { get; set; }
}