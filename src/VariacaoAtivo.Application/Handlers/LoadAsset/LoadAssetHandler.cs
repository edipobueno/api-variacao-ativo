using MassTransit.Mediator;
using MongoDB.Bson;
using VariacaoAtivo.Domain.Handlers.AddAsset;
using VariacaoAtivo.Domain.Handlers.AddAsset.Input;
using VariacaoAtivo.Domain.Handlers.ClearAsset.Input;
using VariacaoAtivo.Domain.Handlers.GetAsset.Input;
using VariacaoAtivo.Domain.Handlers.PatchAddQuotation.Input;
using VariacaoAtivo.Domain.Models;
using VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;
using VariacaoAtivo.Infra.Data.YahooFinance.Input;
using VariacaoAtivo.Infra.MassTransit;
using VariacaoAtivo.Infra.MassTransit.Extensions;

namespace VariacaoAtivo.Application.Chart.Handlers.LoadAsset;

public class LoadAssetHandler : MediatorEvent<LoadAssetRequest>
{
    private readonly IMediator _mediator;

    public LoadAssetHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task Consume(LoadAssetRequest input)
    {
        await _mediator.Send<ClearAssetInput>(new ClearAssetInput()
        {
            Symbol = input.Symbol
        });
        
        var responseAsset = await _mediator.GetResponse<GetAssetInput, Asset>(new GetAssetInput
        {
            Symbol = input.Symbol
        });

        if (responseAsset.Message.IsError)
        {
            var create = new Asset()
            {
                Symbol = input.Symbol, Quotations = new List<Quotation>()
            };

            await _mediator.Send<AddAssetInput>(new AddAssetInput()
            {
                Asset = create
            });

            responseAsset = await _mediator.GetResponse<GetAssetInput, Asset>(new GetAssetInput
            {
                Symbol = input.Symbol
            });
        }

        var asset = responseAsset.Message;

        var yahooAsset = await _mediator.GetResponse<GetChartInput, GetChartOutput>(new GetChartInput
        {
            Symbol = input.Symbol
        });

        if (yahooAsset.Message?.Chart?.Result == null)
            return;

        foreach (var result in yahooAsset.Message?.Chart?.Result!)
        {
            var quoteIndex = 0;

            var index = 0;
            for (int i = 0; i < result.Timestamp.Count; i++)
            {
                var day = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(Convert.ToDouble(result.Timestamp[i]));
                var close = result.Indicators.Quote[quoteIndex].Close[i];
                var low = result.Indicators.Quote[quoteIndex].Low[i];
                var open = result.Indicators.Quote[quoteIndex].Open[i];
                var high = result.Indicators.Quote[quoteIndex].High[i];
                var volume = result.Indicators.Quote[quoteIndex].Volume[i];

                await _mediator.Send<PatchAddQuotationInput>(new PatchAddQuotationInput()
                {
                    Id = asset._id.ToString(), Quotation = new Quotation()
                    {
                        _id = ObjectId.GenerateNewId(), Day = day, Close = close ?? 0, Low = low ?? 0, Open = open ?? 0, High = high ?? 0
                        , Volume = volume ?? 0
                    }
                });
            }
        }
    }
}