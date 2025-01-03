using DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhaAcaoById;
using DnaBrasilApi.Application.LinhasAcoes.Commands.CreateLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Commands.DeleteLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Commands.UpdateLinhaAcao;
using DnaBrasilApi.Application.LinhasAcoes.Queries;
using DnaBrasilApi.Application.LinhasAcoes.Queries.GetLinhasAcoesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class LinhasAcoes : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetLinhasAcoesAll)
            .MapPost(CreateLinhaAcao)
            .MapPut(UpdateLinhaAcao, "{id}")
            .MapDelete(DeleteLinhaAcao, "{id}")
            .MapGet(GetLinhaAcaoById, "LinhaAcao/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão da Linha de açao
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Linha de açao</param>
    /// <returns>Retorna Id da nova Linha de açao</returns>
    public async Task<int> CreateLinhaAcao(ISender sender, CreateLinhaAcaoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração da Linha de açao
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da linha de açao</param>
    /// <param name="command">Objeto de alteração da Linha de açao</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateLinhaAcao(ISender sender, int id, UpdateLinhaAcaoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão da linha de açao
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da linha de açao</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteLinhaAcao(ISender sender, int id)
    {
        return await sender.Send(new DeleteLinhaAcaoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Linhas de açoes cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Linha de Açao</returns>
    public async Task<List<LinhaAcaoDto>> GetLinhasAcoesAll(ISender sender)
    {
        return await sender.Send(new GetLinhasAcoesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Linha de açao
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Linha de açao a ser buscada</param>
    /// <returns>Retorna o objeto da linha de açao </returns>
    public async Task<LinhaAcaoDto> GetLinhaAcaoById(ISender sender, int id)
    {
        return await sender.Send(new GetLinhaAcaoByIdQuery() { Id = id });
    }
    #endregion
}
