using MassTransit.Futures.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VariacaoAtivo.Domain.Models;

public class Asset
{
    [BsonId] public ObjectId _id { get; set; }
    public string Symbol { get; set; }
    public List<Quotation> Quotations { get; set; }

    [BsonIgnore]
    public bool IsError
    {
        get { return _id == ObjectId.Empty; }
    }
}