using DnaBrasil.Application.Locais.Queries;
using DnaBrasil.Application.Locais.Queries.GetLocais;
using DnaBrasil.Application.Localidades.Commands.CreateLocalidade;

namespace DnaBrasil.Web.Endpoints;

public class Localidades : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetLocalidadesAll)
            .MapPost(CreateLocalidade);
    }

    public async Task<List<LocalDto>> GetLocalidadesAll(ISender sender)
    {
        return await sender.Send(new GetLocalidadesAllQuery());
    }
    public async Task<int> CreateLocalidade(ISender sender, CreateLocalidadeCommand command)
    {
        return await sender.Send(command);
    }
}
