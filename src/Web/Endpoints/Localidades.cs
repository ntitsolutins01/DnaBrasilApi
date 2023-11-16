using DnaBrasil.Application.Locais.Queries;
using DnaBrasil.Application.Localidades.Commands.CreateLocalidade;
using DnaBrasil.Application.Localidades.Commands.DeleteLocalidade;
using DnaBrasil.Application.Localidades.Commands.UpdateLocalidade;
using DnaBrasil.Application.Localidades.Queries;
using DnaBrasil.Application.Localidades.Queries.GetLocalidadesAll;

namespace DnaBrasil.Web.Endpoints;

public class Localidades : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLocalidadesAll)
            .MapPost(CreateLocalidade)
            .MapPut(UpdateLocalidade, "{id}")
            .MapDelete(DeleteLocalidade, "{id}");
    }

    public async Task<List<LocalidadeDto>> GetLocalidadesAll(ISender sender)
    {
        return await sender.Send(new GetLocalidadesAllQuery());
    }

    public async Task<int> CreateLocalidade(ISender sender, CreateLocalidadeCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateLocalidade(ISender sender, int id, UpdateLocalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteLocalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteLocalidadeCommand(id));
    }
}
