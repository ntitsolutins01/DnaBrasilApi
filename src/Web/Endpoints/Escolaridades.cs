using DnaBrasil.Application.Escolaridades.Commands.CreateEscolaridade;
using DnaBrasil.Application.Escolaridades.Commands.DeleteEscolaridade;
using DnaBrasil.Application.Escolaridades.Commands.UpdateEscolaridade;
using DnaBrasil.Application.Escolaridades.Queries;
using DnaBrasil.Application.Escolaridades.Queries.GetEscolaridadesAll;

namespace DnaBrasil.Web.Endpoints;

public class Escolaridades : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetEscolaridadesAll)
            .MapPost(CreateEscolaridade)
            .MapPut(UpdateEscolaridade, "{id}")
            .MapDelete(DeleteEscolaridade, "{id}");
    }

    public async Task<List<EscolaridadeDto>> GetEscolaridadesAll(ISender sender)
    {
        return await sender.Send(new GerEscolaridadesAllQuery());
    }

    public async Task<int> CreateEscolaridade(ISender sender, CreateEscolaridadeCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateEscolaridade(ISender sender, int id, UpdateEscolaridadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteEscolaridade(ISender sender, int id)
    {
        return await sender.Send(new DeleteEscolaridadeCommand(id));
    }
}
