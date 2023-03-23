using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Domain.Handlers.PatchBulkQuotation.Input;

public record PatchBulkQuotationInput
{
    public string Id { get; set; }
    public List<Quotation> Quotations { get; init; }
}