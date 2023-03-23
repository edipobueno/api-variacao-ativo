using MassTransit;
using MongoDB.Driver;
using VariacaoAtivo.Domain.Handlers.GetAsset.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.GetAsset;

public class GetAssetHandler : MediatorCommand<GetAssetInput, Asset>
{
    private readonly IBaseCollection<Asset> _repository;

    public GetAssetHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async ValueTask<Asset> Consume(GetAssetInput input)
    {
        var filter = Builders<Asset>.Filter.Eq(x => x.Symbol, input.Symbol);

        var search = await _repository.Collection.FindAsync(filter);

        var response = await search.FirstOrDefaultAsync();

        return response ?? new Asset();
    }
}