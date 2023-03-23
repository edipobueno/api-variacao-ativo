using AutoMapper;
using MassTransit.Mediator;
using VariacaoAtivo.Application.Handlers.GetQuotation.Input;
using VariacaoAtivo.Application.Handlers.GetQuotation.Output;
using VariacaoAtivo.Domain.Handlers.GetQuotation.Input;
using VariacaoAtivo.Domain.Handlers.GetQuotation.Output;
using VariacaoAtivo.Infra.MassTransit;
using VariacaoAtivo.Infra.MassTransit.Extensions;

namespace VariacaoAtivo.Application.Handlers.GetQuotation;

public class GetQuotationsHandler : MediatorCommand<GetQuotationRequest, GetQuotationResponse>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public GetQuotationsHandler(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public override async ValueTask<GetQuotationResponse> Consume(GetQuotationRequest input)
    {
        var quotations = await _mediator.GetResponse<GetQuotationInput, GetQuotationOutput>(new GetQuotationInput
        {
            Symbol = input.Symbol, QuotationsStartsAt = input.StartsAt ?? DateTime.Now.AddDays(-30), QuotationsEndsAt = input.EndsAt ?? DateTime.Now
        });

        var response = _mapper.Map<List<Quotation>>(quotations.Message.Quotations);

        if (input.WithVariations)
        {
            var initialClose = response.FirstOrDefault()!.Close;
            var initialOpen = response.FirstOrDefault()!.Open;
            var initialLow = response.FirstOrDefault()!.Low;
            var initialHigh = response.FirstOrDefault()!.High;
            var initialVolume = response.FirstOrDefault()!.Volume;
            foreach (var quote in response)
            {
                quote.CloseVariation = 1m - (quote.Close / initialClose);
                quote.OpenVariation = 1m - (quote.Open / initialOpen);
                quote.LowVariation = 1m - (quote.Low / initialLow);
                quote.HighVariation = 1m - (quote.High / initialHigh);
                quote.VolumeVariation = 1m - (quote.Volume / initialVolume);
            }
        }

        return new GetQuotationResponse()
        {
            Quotations = response
        };
    }
}