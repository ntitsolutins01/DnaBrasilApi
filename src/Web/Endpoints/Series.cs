using DnaBrasilApi.Application.Series.Commands.CreateSerie;
using DnaBrasilApi.Application.Series.Commands.DeleteSerie;
using DnaBrasilApi.Application.Series.Commands.UpdateSerie;
using DnaBrasilApi.Application.Series.Querries;
using DnaBrasilApi.Application.Series.Querries.GetSeriesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Series : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetSeriesAll)
            .MapPost(CreateSerie)
            .MapPut(UpdateSerie, "{id}")
            .MapDelete(DeleteSerie, "{id}");
    }

    public async Task<List<SerieDto>> GetSeriesAll(ISender sender)
    {
        return await sender.Send(new GetSeriesAllQuery());
    }

    public async Task<int> CreateSerie(ISender sender, CreateSerieCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateSerie(ISender sender, int id, UpdateSerieCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteSerie(ISender sender, int id)
    {
        return await sender.Send(new DeleteSerieCommand(id));
    }
}
