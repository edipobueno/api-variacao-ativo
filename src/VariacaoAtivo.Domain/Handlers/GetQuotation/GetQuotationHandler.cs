using MassTransit;
using MongoDB.Driver;
using VariacaoAtivo.Domain.Handlers.GetAsset.Input;
using VariacaoAtivo.Domain.Handlers.GetQuotation.Input;
using VariacaoAtivo.Domain.Handlers.GetQuotation.Output;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.GetQuotation;

public class GetQuotationHandler : MediatorCommand<GetQuotationInput, GetQuotationOutput>
{
    private readonly IBaseCollection<Asset> _repository;

    public GetQuotationHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async ValueTask<GetQuotationOutput> Consume(GetQuotationInput input)
    {
        var quotations =
            from asset in _repository.Collection.AsQueryable()
            from quote in asset.Quotations
            where
                asset.Symbol == input.Symbol &&
                (
                    quote.Day >= input.QuotationsStartsAt &&
                    quote.Day <= input.QuotationsEndsAt
                )
            select quote;


        var response = quotations.ToList();

        return await ValueTask.FromResult(new GetQuotationOutput()
        {
            Quotations = response
        });
    }
}