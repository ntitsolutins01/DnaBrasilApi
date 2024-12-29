using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadeById;
using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Application.Localidades.Commands.CreateLocalidade;
using DnaBrasilApi.Application.Localidades.Commands.DeleteLocalidade;
using DnaBrasilApi.Application.Localidades.Commands.UpdateLocalidade;
using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesAll;
using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByFomento;
using DnaBrasilApi.Application.Municipios.Queries.GetMunicipiosByUf;
using DnaBrasilApi.Application.Municipios.Queries;
using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByMunicipio;

namespace DnaBrasilApi.Web.Endpoints;

public class Localidades : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLocalidadesAll)
            .MapPost(CreateLocalidade)
            .MapPut(UpdateLocalidade, "{id}")
            .MapDelete(DeleteLocalidade, "{id}")
            .MapGet(GetLocalidadeById, "Localidade/{id}")
            .MapGet(GetLocalidadesByMunicipio, "Municipio/{id}")
            .MapGet(GetLocalidadesByFomento, "Fomento/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Localidade</param>
    /// <returns>Retorna Id da nova Localidade</returns>
    public async Task<int> CreateLocalidade(ISender sender, CreateLocalidadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de localidade</param>
    /// <param name="command">Objeto de alteração de Localidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateLocalidade(ISender sender, int id, UpdateLocalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Localidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteLocalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteLocalidadeCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Aulas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Aulas</returns>
    public async Task<List<LocalidadeDto>> GetLocalidadesAll(ISender sender)
    {
        return await sender.Send(new GetLocalidadesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Aula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Aula a ser buscada</param>
    /// <returns>Retorna o objeto de uma  Localidade </returns>
    public async Task<LocalidadeDto> GetLocalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetLocalidadeByIdQuery() { Id = id });
    }
    /// <summary>
    /// Endpoint que busca Localidade por Municipio
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id de Localidade por Municipio</param>
    /// <returns>retorna uma lista de Localidade</returns>
    public async Task<List<LocalidadeDto>> GetLocalidadesByMunicipio(ISender sender, int id)
    {
        return await sender.Send(new GetLocalidadesByMunicipioQuery { Id = id });
    }

    /// <summary>
    /// Endpoint que busca Localidade por Fomento
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id de Localidade por Fomento</param>
    /// <returns>retorna a uma lista de Localidade</returns>
    public async Task<List<LocalidadeDto>> GetLocalidadesByFomento(ISender sender, int id)
    {
        return await sender.Send(new GetLocalidadesByFomentoQuery { Id = id });
    }
    #endregion
}
