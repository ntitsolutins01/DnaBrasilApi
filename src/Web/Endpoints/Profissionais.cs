using DnaBrasil.Application.Profissionais.Commands.CreateProfissional;
using DnaBrasil.Application.Profissionais.Commands.DeleteProfissional;
using DnaBrasil.Application.Profissionais.Commands.UpdateProfissional;
using DnaBrasil.Application.Profissionais.Commands.UpdateProfissionalAmbientes;
using DnaBrasil.Application.Profissionais.Queries.ProfissionalByFilter;

namespace DnaBrasil.Web.Endpoints;

public class Profissionais : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetProfissionalByFilter)
            .MapPost(CreateProfissional)
            .MapPut(UpdateProfissional, "{id}")
            .MapPut(UpdateProfissionalAmbientes, "UpdateProfissionalAmbientes/{id}")
            .MapDelete(DeleteProfissional, "{id}");
    }

    public async Task<List<ProfissionalDto>> GetProfissionalByFilter(ISender sender, [AsParameters] GetProfissionaisByFilterQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateProfissional(ISender sender, CreateProfissionalCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateProfissional(ISender sender, int id, UpdateProfissionalCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteProfissional(ISender sender, int id)
    {
        await sender.Send(new DeleteProfissionalCommand(id));
        return Results.NoContent();
    }

    public async Task<IResult> UpdateProfissionalAmbientes(ISender sender, int id, UpdateProfissionalAmbientesCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }
}
