using DnaBrasilApi.Application.Contratos.Queries.GetContratoById;
using DnaBrasilApi.Application.Contratos.Queries;
using DnaBrasilApi.Application.Contratos.Commands.CreateContrato;
using DnaBrasilApi.Application.Contratos.Commands.DeleteContrato;
using DnaBrasilApi.Application.Contratos.Commands.UpdateContrato;
using DnaBrasilApi.Application.Contratos.Queries.GetContratosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Contratos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetContratosAll)
            .MapPost(CreateContrato)
            .MapPut(UpdateContrato, "{id}")
            .MapDelete(DeleteContrato, "{id}")
            .MapGet(GetContratoById, "Contrato/{id}");
    }

    public async Task<List<ContratoDto>> GetContratosAll(ISender sender)
    {
        return await sender.Send(new GetContratosAllQuery());
    }

    public async Task<ContratoDto> GetContratoById(ISender sender, int id)
    {
        return await sender.Send(new GetContratoByIdQuery() { Id = id });
    }

    public async Task<int> CreateContrato(ISender sender, CreateContratoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateContrato(ISender sender, int id, UpdateContratoCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteContrato(ISender sender, int id)
    {
        await sender.Send(new DeleteContratoCommand(id));
        return Results.NoContent();
    }
}
