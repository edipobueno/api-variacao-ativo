using System.Text.Json;
using Microsoft.Extensions.Options;
using VariacaoAtivo.Infra.Data.YahooFinance.Chart.Handlers.GetChart.Output;
using VariacaoAtivo.Infra.Data.YahooFinance.Input;
using VariacaoAtivo.Infra.Data.YahooFinance.Startup;
using VariacaoAtivo.Infra.MassTransit;

namespace VariacaoAtivo.Infra.Data.YahooFinance;

public class GetChartHandler : MediatorCommand<GetChartInput, GetChartOutput>
{
    private readonly HttpClient _httpClient;

    public GetChartHandler(IHttpClientFactory factory, IOptions<YahooFinanceConfiguration> configuration)
    {
        _httpClient = factory.CreateClient();
        _httpClient.BaseAddress = new Uri(configuration.Value.ChartUrl);
    }

    public override async ValueTask<GetChartOutput> Consume(GetChartInput input)
    {
        var startsAt = (long)(DateTime.Now.AddDays(-30).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            .TotalSeconds);
        
        var endsAt = (long)(DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
            .TotalSeconds);

        var response = await _httpClient.GetStringAsync($"{input.Symbol}?interval=1d&range=10y");

        if (string.IsNullOrWhiteSpace(response))
            return new GetChartOutput();

        return JsonSerializer.Deserialize<GetChartOutput>(response)!;
    }
}