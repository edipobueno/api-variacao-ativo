using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Domain.Handlers.PatchAddQuotation.Input;

public record PatchAddQuotationInput
{
    public string Id { get; set; }
    public Quotation Quotation { get; init; }
}