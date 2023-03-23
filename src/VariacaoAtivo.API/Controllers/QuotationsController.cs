using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivo.Application.Handlers.GetQuotation.Input;
using VariacaoAtivo.Application.Handlers.GetQuotation.Output;
using VariacaoAtivo.Infra.MassTransit.Extensions;

namespace VariacaoAtivo.API.Controllers;

[ApiController]
[Route("Assets/{symbol}/[controller]")]
public class QuotationsController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuotationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetQuotationResponse>), 200)]
    public async ValueTask<ActionResult<Quotation>> GetQuotationBySymbol([FromRoute] string symbol, 
        [FromQuery] DateTime? startsAt = null,
        [FromQuery] DateTime? endsAt = null,
        [FromQuery] bool withVariation = false)
    {
        var response = await _mediator.GetResponse<GetQuotationRequest, GetQuotationResponse>(new GetQuotationRequest
        {
            Symbol = symbol,
            StartsAt = startsAt,
            EndsAt = endsAt,
            WithVariations = withVariation
        });

        return Ok(response.Message.Quotations);
    }
}