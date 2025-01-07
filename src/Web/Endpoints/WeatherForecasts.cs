using DnaBrasilApi.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
///  Api de Weather Forecasts
/// </summary>
public class WeatherForecasts : EndpointGroupBase
{
    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    /// <summary>
    /// Endpoint que busca todas as Previsões Meteorológicas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Previsões meteorológicas</returns>
    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}
