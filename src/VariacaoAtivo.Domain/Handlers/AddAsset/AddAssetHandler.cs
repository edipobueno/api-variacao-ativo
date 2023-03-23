using VariacaoAtivo.Domain.Handlers.AddAsset.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Domain.Handlers.AddAsset;

public class AddAssetHandler : MediatorEvent<AddAssetInput>
{
    private readonly IBaseCollection<Asset> _repository;

    public AddAssetHandler(IBaseCollection<Asset> repository)
    {
        _repository = repository;
    }

    public override async Task Consume(AddAssetInput input)
    {
        await _repository.Collection.InsertOneAsync(input.Asset);
    }
}