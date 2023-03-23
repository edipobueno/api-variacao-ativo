using MongoDB.Driver;
using VariacaoAtivo.Domain.Handlers.ClearAsset.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.ClearAsset;

public class ClearAssetHandler : MediatorEvent<ClearAssetInput>
{
    private readonly IBaseCollection<Asset> _repository;

    public ClearAssetHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async Task Consume(ClearAssetInput input)
    {
        var filter = Builders<Asset>.Filter.Eq(asset => asset.Symbol, input.Symbol);
        var patch = Builders<Asset>.Update.Set(asset => asset.Quotations, new List<Quotation>());

        await _repository.Collection.UpdateOneAsync(filter, patch);
    }
}