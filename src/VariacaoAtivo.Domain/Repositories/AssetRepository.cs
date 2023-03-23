using MongoDB.Driver;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.MongoDb;

namespace VariacaoAtivo.Domain.Repositories;

public class AssetRepository : BaseCollection<Asset>
{
    public AssetRepository(string connectionString) : base(connectionString)
    {
    }

    protected override string DatabaseName => "VariacaoAtivo";
    protected override string CollectionName => "Assets";
}