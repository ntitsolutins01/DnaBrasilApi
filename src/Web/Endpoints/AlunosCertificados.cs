using DnaBrasilApi.Application.AlunosCertificados.Queries.GetAlunoCertificadoById;
using DnaBrasilApi.Application.AlunosCertificados.Commands.CreateAlunoCertificado;
using DnaBrasilApi.Application.AlunosCertificados.Commands.DeleteAlunoCertificado;
using DnaBrasilApi.Application.AlunosCertificados.Commands.UpdateAlunoCertificado;
using DnaBrasilApi.Application.AlunosCertificados.Queries;
using DnaBrasilApi.Application.AlunosCertificados.Queries.GetAlunosCertificadosAll;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de AlunosCertificados
/// </summary>
public class AlunosCertificados : EndpointGroupBase
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
            .MapGet(GetAlunosCertificadosAll)
            .MapPost(CreateAlunoCertificado)
            .MapPut(UpdateAlunoCertificado, "{id}")
            .MapDelete(DeleteAlunoCertificado, "{id}")
            .MapGet(GetAlunoCertificadoById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de AlunoCertificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da AlunoCertificado</param>
    /// <returns>Retorna Id da nova AlunoCertificado</returns>
    public async Task<int> CreateAlunoCertificado(ISender sender, CreateAlunoCertificadoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de AlunoCertificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da AlunoCertificado</param>
    /// <param name="command">Objeto de alteração da AlunoCertificado</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAlunoCertificado(ISender sender, int id, UpdateAlunoCertificadoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de AlunoCertificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da AlunoCertificado</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAlunoCertificado(ISender sender, int id)
    {
        return await sender.Send(new DeleteAlunoCertificadoCommand(id));
    }
    #endregion 

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as AlunosCertificados cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de AlunosCertificados</returns>
    public async Task<List<AlunoCertificadoDto>> GetAlunosCertificadosAll(ISender sender)
    {
        return await sender.Send(new GetAlunosCertificadosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única AlunoCertificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da AlunoCertificado a ser buscada</param>
    /// <returns>Retorna o objeto da AlunoCertificado </returns>
    public async Task<AlunoCertificadoDto> GetAlunoCertificadoById(ISender sender, int id)
    {
        return await sender.Send(new GetAlunoCertificadoByIdQuery() { Id = id });
    }
    #endregion

}
