using DnaBrasilApi.Application.Deficiencias.Commands.CreateDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Commands.DeleteDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Commands.UpdateDeficiencia;
using DnaBrasilApi.Application.Deficiencias.Queries;
using DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciaById;
using DnaBrasilApi.Application.Deficiencias.Queries.GetDeficienciasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Deficiencias : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetDeficienciasAll)
            .MapGet(GetDeficienciaById, "Deficiencia/{id}")
            .MapPost(CreateDeficiencia)
            .MapPut(UpdateDeficiencia, "{id}")
            .MapDelete(DeleteDeficiencia, "{id}");
    }

    public async Task<List<DeficienciaDto>> GetDeficienciasAll(ISender sender)
    {
        return await sender.Send(new GetDeficienciasAllQuery());
    }
    public async Task<DeficienciaDto> GetDeficienciaById(ISender sender, int id)
    {
        return await sender.Send(new GetDeficienciaByIdQuery() { Id = id });
    }

    public async Task<int> CreateDeficiencia(ISender sender, CreateDeficienciaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateDeficiencia(ISender sender, int id, UpdateDeficienciaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteDeficiencia(ISender sender, int id)
    {
        return await sender.Send(new DeleteDeficienciaCommand(id));
    }
}
