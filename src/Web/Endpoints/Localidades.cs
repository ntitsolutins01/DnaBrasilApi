using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadeById;
using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Application.Localidades.Commands.CreateLocalidade;
using DnaBrasilApi.Application.Localidades.Commands.DeleteLocalidade;
using DnaBrasilApi.Application.Localidades.Commands.UpdateLocalidade;
using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Localidades : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLocalidadesAll)
            .MapPost(CreateLocalidade)
            .MapPut(UpdateLocalidade, "{id}")
            .MapDelete(DeleteLocalidade, "{id}")
            .MapGet(GetLocalidadeById, "Localidade/{id}");
    }

    public async Task<List<LocalidadeDto>> GetLocalidadesAll(ISender sender)
    {
        return await sender.Send(new GetLocalidadesAllQuery());
    }

    public async Task<LocalidadeDto> GetLocalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetLocalidadeByIdQuery() { Id = id });
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
