using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Domain.Handlers.GetQuotation.Output;

public record GetQuotationOutput
{
    public List<Quotation> Quotations { get; set; }
}