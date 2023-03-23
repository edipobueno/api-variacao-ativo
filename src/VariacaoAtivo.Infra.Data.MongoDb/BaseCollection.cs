using MongoDB.Driver;
using VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;

namespace VariacaoAtivo.Infra.Data.MongoDb;

public abstract class BaseCollection<T> : IBaseCollection<T>
    where T : class
{
    public IMongoCollection<T> Collection { get; }
    protected abstract string DatabaseName { get; }
    protected abstract string CollectionName { get; }

    public BaseCollection(string connectionString)
    {
        if (CollectionName == null)
            return;

        if (DatabaseName == null)
            return;

        Collection = new MongoClient(connectionString).GetDatabase(DatabaseName).GetCollection<T>(CollectionName);
    }
}