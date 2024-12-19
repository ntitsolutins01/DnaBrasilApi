using DnaBrasilApi.Application.Funcionalidades.Commands.CreateFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Commands.DeleteFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Commands.UpdateFuncionalidade;
using DnaBrasilApi.Application.Funcionalidades.Queries;
using DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadeById;
using DnaBrasilApi.Application.Funcionalidades.Queries.GetFuncionalidadesAll;
using DnaBrasilApi.Application.Modulos.Commands.CreateModulo;
using DnaBrasilApi.Application.Modulos.Commands.DeleteModulo;
using DnaBrasilApi.Application.Modulos.Commands.UpdateModulo;
using DnaBrasilApi.Application.Modulos.Queries.GetModuloById;
using DnaBrasilApi.Application.Modulos.Queries.GetModulosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class ConfiguracaoSistema : EndpointGroupBase
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
            .MapGet(GetModulosAll, "Modulos")
            .MapGet(GetModuloById, "Modulo/{id}")
            .MapPost(CreateModulo, "Modulo")
            .MapPut(UpdateModulo, "{id}")
            .MapDelete(DeleteModulo, "{id}")
            .MapGet(GetFuncionalidadesAll, "Funcionalidades")
            .MapGet(GetFuncionalidadeById, "Funcionalidade/{id}")
            .MapPost(CreateFuncionalidade, "Funcionalidade")
            .MapPut(UpdateFuncionalidade, "Funcionalidade/{id}")
            .MapDelete(DeleteFuncionalidade, "Funcionalidade/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Funcionalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Funcionalidade</param>
    /// <returns>Retorna Id da nova Funcionalidade</returns>
    public async Task<int> CreateFuncionalidade(ISender sender, CreateFuncionalidadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Funcionalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Funcionalidade</param>
    /// <param name="command">Objeto de alteração da Funcionalidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateFuncionalidade(ISender sender, int id, UpdateFuncionalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Funcionalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Funcionalidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteFuncionalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteFuncionalidadeCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Funcionalidades cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Funcionalidades</returns>
    public async Task<List<FuncionalidadeDto>> GetFuncionalidadesAll(ISender sender)
    {
        return await sender.Send(new GetFuncionalidadesAllQuery());
    }
    public async Task<FuncionalidadeDto> GetFuncionalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetFuncionalidadeByIdQuery() { Id = id });
    }
    public async Task<ModuloDto> GetModuloById(ISender sender, int id)
    {
        return await sender.Send(new GetModuloByIdQuery() { Id = id });
    }
    #endregion





    public async Task<int> CreateModulo(ISender sender, CreateModuloCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<bool> UpdateModulo(ISender sender, int id, UpdateModuloCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> DeleteModulo(ISender sender, int id)
    {
        return await sender.Send(new DeleteModuloCommand(id));
    }
    public async Task<List<ModuloDto>> GetModulosAll(ISender sender)
    {
        return await sender.Send(new GetModulosAllQuery());
    }

    
}
