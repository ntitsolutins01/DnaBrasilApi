using DnaBrasilApi.Application.TipoLaudos.Commands.CreateTipoLaudos;
using DnaBrasilApi.Application.TipoLaudos.Commands.DeleteTipoLaudos;
using DnaBrasilApi.Application.TipoLaudos.Commands.UpdateTipoLaudo;
using DnaBrasilApi.Application.TipoLaudos.Queries;
using DnaBrasilApi.Application.TipoLaudos.Queries.GetTipoLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class TiposLaudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTiposLaudosAll)
            .MapPost(CreateTipoLaudo)
            .MapPut(UpdateTipoLaudo, "{id}")
            .MapDelete(DeleteTipoLaudo, "{id}");
    }

    public async Task<List<TipoLaudoDto>> GetTiposLaudosAll(ISender sender)
    {
        return await sender.Send(new GetTipoLaudosAllQuery());
    }

    public async Task<int> CreateTipoLaudo(ISender sender, CreateTipoLaudosCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateTipoLaudo(ISender sender, int id, UpdateTipoLaudoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteTipoLaudo(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoLaudoCommand(id));
    }
}
