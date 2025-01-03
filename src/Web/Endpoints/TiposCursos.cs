using DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursoById;
using DnaBrasilApi.Application.TipoCursos.Queries;
using DnaBrasilApi.Application.TipoCursos.Commands.CreateTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Commands.DeleteTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Commands.UpdateTipoCurso;
using DnaBrasilApi.Application.TipoCursos.Queries.GetTipoCursosAll;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
///  Api de tipos de Cursos 
/// </summary>
public class TiposCursos : EndpointGroupBase
{
    #region MapEndpoints

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetTiposCursosAll)
            .MapPost(CreateTipoCurso)
            .MapPut(UpdateTipoCurso, "{id}")
            .MapDelete(DeleteTipoCurso, "{id}")
            .MapGet(GetTipoCursoById, "TipoCurso/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Tipo de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Tipo de Curso</param>
    /// <returns>Retorna Id de novo Tipo de Curso</returns>
    public async Task<int> CreateTipoCurso(ISender sender, CreateTipoCursoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Tipo de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Tipo de Curso</param>
    /// <param name="command">Objeto de alteração de Tipo de Curso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateTipoCurso(ISender sender, int id, UpdateTipoCursoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Tipo de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de Tipo de Curso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteTipoCurso(ISender sender, int id)
    {
        return await sender.Send(new DeleteTipoCursoCommand(id));
    }
    #endregion

    #region Get Methods
    /// <summary>
    /// Endpoint que busca todos os Tipos de Cursos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Tipo de Curso</returns>
    public async Task<List<TipoCursoDto>> GetTiposCursosAll(ISender sender)
    {
        return await sender.Send(new GetTipoCursosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Tipo de Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Tipo de Curso a ser buscado</param>
    /// <returns>Retorna o objeto da Aula </returns>
    public async Task<TipoCursoDto> GetTipoCursoById(ISender sender, int id)
    {
        return await sender.Send(new GetTipoCursoByIdQuery() { Id = id });
    }
    #endregion
}
