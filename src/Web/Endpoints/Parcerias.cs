using DnaBrasilApi.Application.TiposParcerias.Commands.CreateTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Commands.DeleteTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Commands.UpdateTipoParceria;
using DnaBrasilApi.Application.TiposParcerias.Queries;
using DnaBrasilApi.Application.TiposParcerias.Queries.GetTipoParceriaById;
using DnaBrasilApi.Application.TiposParcerias.Queries.GetTiposParceriasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class TipoParcerias : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTiposParceriasAll)
            .MapPost(CreateTipoParceria)
            .MapPut(UpdateTipoParceria, "{id}")
            .MapDelete(DeleteTipoParceria, "{id}")
            .MapGet(GetTipoParceriaById, "TipoParceria/{id}");
    }

    public async Task<List<TipoParceriaDto>> GetTiposParceriasAll(ISender sender)
    {
        return await sender.Send(new GetTiposParceriasQuery());
    }

    public async Task<TipoParceriaDto> GetTipoParceriaById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoParceriaByIdQuery() { Id = id });
    }
    public async Task<int> CreateTipoParceria(ISender sender, CreateTipoParceriaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateTipoParceria(ISender sender, int id, UpdateTipoParceriaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteTipoParceria(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoParceriaCommand(id));
    }
}
