using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.CreateControleFrequenciaEscolar;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.DeleteControleFrequenciaEscolar;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Commands.UpdateControleFrequenciaEscolar;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControleFrequenciaEscolarById;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresAll;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresByAlunoId;
using DnaBrasilApi.Application.ControlesFrequenciasEscolares.Queries.GetControlesFrequenciasEscolaresByAlunoMesAno;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de Controle de FrequenciasEscolares
/// </summary>
public class ControlesFrequenciasEscolares : EndpointGroupBase
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
            .MapGet(GetControlesFrequenciasEscolaresAll)
            .MapPost(CreateControleFrequenciaEscolar)
            .MapPut(UpdateControleFrequenciaEscolar, "{id}")
            .MapDelete(DeleteControleFrequenciaEscolar, "{id}")
            .MapGet(GetControleFrequenciaEscolarById, "{id}")
            .MapGet(GetControlesFrequenciasEscolaresByAlunoId, "Aluno/{id}")
            .MapGet(GetControlesFrequenciasEscolaresByAlunoMesAno, "Aluno/{alunoId}/Mes/{mes}/Ano/{ano}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Controle de Frequencia Escolar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da de Frequencia Escolar</param>
    /// <returns>Retorna Id do novo Controle de Frequencia Escolar</returns>
    public async Task<int> CreateControleFrequenciaEscolar(ISender sender, CreateControleFrequenciaEscolarCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Controle Frequencia Escolar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Frequencia Escolar</param>
    /// <param name="command">Objeto de alteração da Frequencia Escolar</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateControleFrequenciaEscolar(ISender sender, int id, UpdateControleFrequenciaEscolarCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Controle Frequencia Escolar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Frequencia Escolar</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteControleFrequenciaEscolar(ISender sender, int id)
    {
        return await sender.Send(new DeleteControleFrequenciaEscolarCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as ControlesFrequenciasEscolares cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de ControlesFrequenciasEscolares</returns>
    public async Task<List<ControleFrequenciaEscolarDto>> GetControlesFrequenciasEscolaresAll(ISender sender)
    {
        return await sender.Send(new GetControlesFrequenciasEscolaresAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Controle Frequencia Escolar
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Frequencia Escolar a ser buscada</param>
    /// <returns>Retorna o objeto da Frequencia Escolar </returns>
    public async Task<ControleFrequenciaEscolarDto> GetControleFrequenciaEscolarById(ISender sender, int id)
    {
        return await sender.Send(new GetControleFrequenciaEscolarByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de frequencias escolares pelo aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do aluno</param>
    /// <returns>Retorna uma lista de Frequencias Escolares</returns>
    public async Task<List<ControleFrequenciaEscolarDto>> GetControlesFrequenciasEscolaresByAlunoId(ISender sender, int id)
    {
        return await sender.Send(new GetControlesFrequenciasEscolaresByAlunoIdQuery() { AlunoId = id });
    }

    /// <summary>
    /// Endpoint que busca as frequências de um aluno do mes informado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="alunoId">Id do Aluno</param>
    /// <param name="mes">Mes</param>
    /// <param name="ano">Ano</param>
    /// <returns>Retorna uma lista de frequências do mês ano informado </returns>
    public async Task<List<ControleFrequenciaEscolarDto>> GetControlesFrequenciasEscolaresByAlunoMesAno(ISender sender, int alunoId, int mes, int ano)
    {
        return await sender.Send(new GetControlesFrequenciasEscolaresByAlunoMesAnoQuery() { AlunoId = alunoId, Mes = mes, Ano = ano });
    }

    #endregion
}
