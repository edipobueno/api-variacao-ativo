using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivo.Application.Chart.Handlers.LoadAsset;
using VariacaoAtivo.Application.Handlers.GetQuotation.Output;

namespace VariacaoAtivo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AssetsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssetsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("load")]
    [ProducesResponseType(statusCode: 204)]
    public async Task<ActionResult> LoadAssetBySymbol(LoadAssetRequest request)
    {
        await _mediator.Send(request);

        return NoContent();
    }
}