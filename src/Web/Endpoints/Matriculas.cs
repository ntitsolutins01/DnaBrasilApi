using DnaBrasilApi.Application.Alunos.Commands.CreateMatricula;
using DnaBrasilApi.Application.Alunos.Commands.UpdateMatricula;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetMatriculasAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Matriculas : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetMatriculasAll)
            .MapPost(CreateMatricula)
            .MapPut(UpdateMatricula, "{id}");

    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão da Matricula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Matricula</param>
    /// <returns>Retorna Id da nova Matricula </returns>
    public async Task<int> CreateMatricula(ISender sender, CreateMatriculaCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração da Matricula
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Matricula</param>
    /// <param name="command">Objeto de alteração da Matricula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateMatricula(ISender sender, int id, UpdateMatriculaCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Matriculas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Matricula</returns>
    public async Task<List<MatriculaDto>> GetMatriculasAll(ISender sender)
    {
        return await sender.Send(new GetMatriculasAllQuery());
    }
    #endregion
}
