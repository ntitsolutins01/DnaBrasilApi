using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoSaudeBucal;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivoV1;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoVocacional;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByQualidadeDeVidaId;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudoByAluno;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoBySaudeId;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.Laudos.Commands.UpdateLaudo;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByVocacional;
using DnaBrasilApi.Application.Laudos.Queries.GetDesempenhoByAluno;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudoById;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosByFilter;
using Microsoft.AspNetCore.Mvc;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoQualidadeVida;

namespace DnaBrasilApi.Web.Endpoints;

public class Laudos : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization() 
            .MapGet(GetLaudoById, "{id}")
            .MapPost(CreateLaudo)
            .MapPut(UpdateLaudo, "{id}")
            .MapPut(UpdateEncaminhamentoTalentoEsportivo, "Encaminhamento/TalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoTalentoEsportivoV1, "v1/Encaminhamento/TalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoSaudeBucal, "Encaminhamento/SaudeBucal/{alunoId}")
            .MapPut(UpdateEncaminhamentoVocacional, "Encaminhamento/Vocacional/{alunoId}")
            .MapPut(UpdateEncaminhamentoQualidadeDeVida, "Encaminhamento/QualidadeDeVida/{alunoId}")
            .MapPut(UpdateEncaminhamentoConsumoAlimentar, "Encaminhamento/ConsumoAlimentar/{alunoId}")
            .MapGet(GetLaudosAll)
            .MapGet(GetLaudoByAluno, "Aluno/{id}")
            .MapGet(GetEncaminhamentoBySaudeId, "Encaminhamento/Saude/{id}")
            .MapGet(GetEncaminhamentoByQualidadeDeVidaId, "Encaminhamento/QualidadeDeVida/{id}")
            .MapGet(GetEncaminhamentoByVocacional, "Encaminhamentos/Vocacional")
            .MapGet(GetDesempenhoByAluno, "Desempenho/{id}")
            .MapPost(GetLaudosByFilter, "Filter");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Laudos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Laudos</param>
    /// <returns>Retorna Id de novo Laudos</returns>
    public async Task<int> CreateLaudo(ISender sender, CreateLaudoCommand command)
    {
        return await sender.Send(command);
    }
    /// <summary>
    /// Endpoint para alteração de Laudos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Laudos</param>
    /// <param name="command">Objeto de alteração de Laudos</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateLaudo(ISender sender, int id, UpdateLaudoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    /// <summary>
    /// Endpoint para alteração de Encaminhamento Talanto Esportivo
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Encaminhamento Talento Esportivo</param>
    /// <param name="command">Objeto de alteração de Encaminhamento Talento Escportivo</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoTalentoEsportivo(ISender sender, int alunoId)
    {
        var result = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(alunoId));
        return result;
    }
    /// <summary>
    /// Endpoint para alteração de Encaminhamento Talento Esportivo V1
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Encaminhamento Talento Esportivo V1</param>
    /// <param name="command">Objeto de alteração de Encaminhamento Talento Esportivo V1</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoTalentoEsportivoV1(ISender sender, int alunoId, UpdateEncaminhamentoTalentoEsportivoV1Command command)
    {
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Encaminhamento Vocacional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Encaminhamento Vocacional</param>
    /// <param name="command">Objeto de alteração de Encaminhamento Vocacional</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoVocacional(ISender sender, int alunoId, UpdateEncaminhamentoVocacionalCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Encaminhamento de Qualidade De Vida
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Emcaminhamneto Qualidade de Vida</param>
    /// <param name="command">Objeto de alteração da Aula</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoQualidadeDeVida(ISender sender, int alunoId, UpdateEncaminhamentoQualidadeDeVidaCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Encaminhamento de Consumo de Alimentos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Encaminhamento de Consumo de Alimentos</param>
    /// <param name="command">Objeto de alteração da Encaminhamento de Consumo de Alimentos</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoConsumoAlimentar(ISender sender, int alunoId, UpdateEncaminhamentoConsumoAlimentarCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Encaminhamento de Saúde Bucal
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Encaminhamento de Saúde Bucal</param>
    /// <param name="command">Objeto de alteração de Encaminhamento de Saúde Bucal</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateEncaminhamentoSaudeBucal(ISender sender, int alunoId, UpdateEncaminhamentoSaudeBucalCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Aulas cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Aulas</returns>
    public async Task<PaginatedList<LaudoDto>> GetLaudosAll(ISender sender, [AsParameters] GetLaudosAllQuery query)
    {
        return await sender.Send(query);
    }
    /// <summary>
    /// Endpoint que busca todos os Laudos por Aluno
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id que busca laudos por Aluno</param>
    /// <returns>retorna a lista de Laudos por Aluno </returns>
    public async Task<LaudoDto> GetLaudoByAluno(ISender sender, int id)
    {
        var laudo = await sender.Send(new GetLaudoByAlunoQuery(id));
        return laudo;
    }
    /// <summary>
    /// Endpoint que busca Laudos por Id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id que busca Laudos por id</param>
    /// <returns>retorna a lista de Laudos por Id</returns>
    public async Task<LaudoDto> GetLaudoById(ISender sender, int id)
    {
        var laudo = await sender.Send(new GetLaudoByIdQuery(id));
        return laudo;
    }

    /// <summary>
    /// Endpoint que busca Encaminhamento Saúde por Id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id que busca Ecaminhamento Saúde por id</param>
    /// <returns>retorna a lista de Encaminhamento Saúde por id</returns>
    public async Task<EncaminhamentoDto> GetEncaminhamentoBySaudeId(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentoBySaudeIdQuery(id));
    }
    /// <summary>
    /// Endpoint que busca Encaminhamento Quialidade de Vida por id
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id que busca Encaminhamento Qualidade de Vidas por id</param>
    /// <returns>retorna a lista de Encaminhamento Qualidade de Vida por id</returns>
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentoByQualidadeDeVidaId(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentoByQualidadeDeVidaIdQuery(id));
    }
    /// <summary>
    /// Endpoint que busca Encaminhamento por Vocacional
    /// </summary>
    /// <param name="sender">sender</param>
    /// <returns>retorna a lista de Encaminhamento Vocacional</returns>
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentoByVocacional(ISender sender)
    {
        return await sender.Send(new GetEncaminhamentoByVocacionalQuery());
    }
    /// <summary>
    /// Endpoint que busca Desempenho por Aluno
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">ide que busca Desempenho por Aluno</param>
    /// <returns>retorna lista de Desempenho por Aluno</returns>
    public async Task<DesempenhoDto> GetDesempenhoByAluno(ISender sender, int id)
    {
        return await sender.Send(new GetDesempenhoByAlunoQuery(id));

    }
    /// <summary>
    /// Endpoint que busca Laudos por Filtro
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="search">filtro para pesquisa de Laudos</param>
    /// <returns>retorna a lista de laudos por Filtro</returns>
    public async Task<LaudosFilterDto> GetLaudosByFilter(ISender sender, [FromBody] LaudosFilterDto search)
    {
        //var usuario = await sender.Send(new GetUsuarioByEmailQuery() { Email = search.UsuarioEmail! });

        //search.MunicipioId = usuario.MunicipioId;
        //search.Estado = usuario.Uf;

        var result = await sender.Send(new GetLaudosByFilterQuery() { SearchFilter = search });

        search.Laudos = result;

        return search;
    }
    #endregion
}
