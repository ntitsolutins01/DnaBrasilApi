﻿
using DnaBrasilApi.Application.Estados.Queries;
using DnaBrasilApi.Application.Estados.Queries.GetEstadoByUf;
using DnaBrasilApi.Application.Estados.Queries.GetEstadosAll;
using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Application.Municipios.Queries.GetMunicipiosByUf;

namespace DnaBrasilApi.Web.Endpoints;

public class DivisoesAdministrativas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetEstadosAll, "Estados")
            .MapGet(GetMunicipiosByUf, "Municipios/{uf}")
            .MapGet(GetEstadoByUf, "Estado/{uf}");
    }

    public async Task<List<EstadoDto>> GetEstadosAll(ISender sender)
    {
        return await sender.Send(new GetEstadosAllQuery());
    }

    public async Task<List<MunicipioDto>> GetMunicipiosByUf(ISender sender, string uf)
    {
        return await sender.Send(new GetMunicipioByUfQuery { Uf = uf });
    }

        public async Task<EstadoDto> GetEstadoByUf(ISender sender, string uf)
        {
            return await sender.Send(new GetEstadoByUfQuery() { Uf = uf });
        }
}
