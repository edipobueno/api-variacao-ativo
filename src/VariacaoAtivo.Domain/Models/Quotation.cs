using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VariacaoAtivo.Domain.Models;

public class Quotation
{
    [BsonId] public ObjectId _id { get; set; }
    public DateTime Day { get; set; }
    public decimal Close { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public int Volume { get; set; }
}