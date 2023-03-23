using MongoDB.Bson;
using MongoDB.Driver;
using VariacaoAtivo.Domain.Handlers.PatchBulkQuotation.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.PatchBulkQuotation;

public class PatchBulkQuotationHandler : MediatorEvent<PatchBulkQuotationInput>
{
    private readonly IBaseCollection<Asset> _repository;

    public PatchBulkQuotationHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async Task Consume(PatchBulkQuotationInput input)
    {
        var filter = Builders<Asset>.Filter.Eq(asset => asset._id, ObjectId.Parse(input.Id));
        var patch = Builders<Asset>.Update.AddToSetEach(asset => asset.Quotations, input.Quotations);

        await _repository.Collection.UpdateOneAsync(filter, patch);
    }
}