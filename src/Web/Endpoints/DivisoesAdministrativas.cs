
using DnaBrasilApi.Application.Estados.Queries;
using DnaBrasilApi.Application.Estados.Queries.GetEstadoByUf;
using DnaBrasilApi.Application.Estados.Queries.GetEstadosAll;
using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Application.Municipios.Queries.GetMunicipioById;
using DnaBrasilApi.Application.Municipios.Queries.GetMunicipiosByUf;

namespace DnaBrasilApi.Web.Endpoints;

public class DivisoesAdministrativas : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetEstadosAll, "Estados")
            .MapGet(GetMunicipiosByUf, "Municipios/{uf}")
            .MapGet(GetMunicipioById, "Municipio/{id}")
            .MapGet(GetEstadoByUf, "Estado/{uf}");
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca todos os Estados
    /// </summary>
    /// <param name="sender">sender</param>
    /// <returns>Retorna uma Divisao Administrativa</returns>
    public async Task<List<EstadoDto>> GetEstadosAll(ISender sender)
    {
        return await sender.Send(new GetEstadosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca todos os Municipios pela Uf
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="uf"></param>
    /// <returns>Retorna uma Divisao Administrativa</returns>
    public async Task<List<MunicipioDto>> GetMunicipiosByUf(ISender sender, string uf)
    {
        return await sender.Send(new GetMunicipioByUfQuery { Uf = uf });
    }

    /// <summary>
    /// Endpoint que busca o Estado pela Uf
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="uf"></param>
    /// <returns></returns>
    public async Task<EstadoDto> GetEstadoByUf(ISender sender, string uf)
    {
        return await sender.Send(new GetEstadoByUfQuery() { Uf = uf });
    }

    /// <summary>
    /// Endpoint que busca o Municipio pelo Id
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<MunicipioDto> GetMunicipioById(ISender sender, int id)
    {
        return await sender.Send(new GetMunicipioByIdQuery() { Id = id });
    }

    #endregion







}
