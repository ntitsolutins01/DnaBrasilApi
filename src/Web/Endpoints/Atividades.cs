using DnaBrasilApi.Application.Atividades.Queries.GetAtividadeById;
using DnaBrasilApi.Application.Atividades.Commands.CreateAtividade;
using DnaBrasilApi.Application.Atividades.Commands.DeleteAtividade;
using DnaBrasilApi.Application.Atividades.Commands.UpdateAtividade;
using DnaBrasilApi.Application.Atividades.Queries;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadesAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Atividades : EndpointGroupBase
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
            .MapPost(CreateAtividade)
            .MapPut(UpdateAtividade, "{id}")
            .MapDelete(DeleteAtividade, "{id}")
            .MapGet(GetAtividadesAll)
            .MapGet(GetAtividadeById, "Atividade/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Atividade</param>
    /// <returns>Retorna Id da nova Atividade</returns>
    public async Task<int> CreateAtividade(ISender sender, CreateAtividadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Atividade</param>
    /// <param name="command">Objeto de alteração da Atividade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAtividade(ISender sender, int id, UpdateAtividadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Atividade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAtividade(ISender sender, int id)
    {
        return await sender.Send(new DeleteAtividadeCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Atividades cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Atividades</returns>
    public async Task<List<AtividadeDto>> GetAtividadesAll(ISender sender)
    {
        return await sender.Send(new GetAtividadesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Atividade a ser buscada</param>
    /// <returns>Retorna o objeto da Atividade </returns>
    public async Task<AtividadeDto> GetAtividadeById(ISender sender, int id)
    {
        return await sender.Send(new GetAtividadeByIdQuery() { Id = id });
    }
    #endregion

}
