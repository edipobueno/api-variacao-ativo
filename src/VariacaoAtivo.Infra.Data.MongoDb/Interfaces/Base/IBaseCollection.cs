using MongoDB.Driver;

namespace VariacaoAtivo.Infra.Data.MongoDb.Interfaces.Base;

public interface IBaseCollection<T>
{
    IMongoCollection<T> Collection { get; }
}