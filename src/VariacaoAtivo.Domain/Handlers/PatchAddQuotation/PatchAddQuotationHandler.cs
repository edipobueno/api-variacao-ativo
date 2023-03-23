using MongoDB.Bson;
using MongoDB.Driver;
using VariacaoAtivo.Domain.Handlers.PatchAddQuotation.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.PatchAddQuotation;

public class PatchAddQuotationHandler : MediatorEvent<PatchAddQuotationInput>
{
    private readonly IBaseCollection<Asset> _repository;

    public PatchAddQuotationHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async Task Consume(PatchAddQuotationInput input)
    {
        var filter = Builders<Asset>.Filter.Eq(asset => asset._id, ObjectId.Parse(input.Id));
        var patch = Builders<Asset>.Update.AddToSet(asset => asset.Quotations, input.Quotation);

        await _repository.Collection.UpdateOneAsync(filter, patch);
    }
}