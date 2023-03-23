using AutoMapper;
using MongoDB.Bson;
using VariacaoAtivo.Domain.Models;

namespace VariacaoAtivo.Application.Profiles;

public class AssetProfile : Profile
{
    public AssetProfile()
    {
        CreateMap<Quotation, Handlers.GetQuotation.Output.Quotation>()
            .ForMember(dest => dest.Id, cfg => { cfg.MapFrom(src => src._id.ToString()); })
            .ReverseMap()
            .ForMember(dest => dest._id, cfg => { cfg.MapFrom(src => ObjectId.Parse(src.Id.ToString())); });
    }
}