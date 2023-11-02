using DnaBrasil.Application.Estados.Queries.GetEstadosAll;
using DnaBrasil.Application.Municipios.Queries;
using DnaBrasil.Application.Municipios.Queries.GetMunicipiosByUf;

namespace DnaBrasil.Web.Endpoints;

public class DivisaoAdministrativa : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetEstadosAll, "Estados")
            .MapGet(GetMunicipiosByUf, "Municipios/{uf}");
    }

    public async Task<List<EstadoDto>> GetEstadosAll(ISender sender)
    {
        return await sender.Send(new GetEstadosAllQuery());
    }

    public async Task<List<MunicipioDto>> GetMunicipiosByUf(ISender sender, string uf)
    {
        return await sender.Send(new GetMunicipioByUfQuery { Uf = uf });
    }
}
