using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoSaudeBucal;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivoV1;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByQualidadeDeVidaId;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudoByAluno;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoBySaudeId;
using DnaBrasilApi.Application.Laudos.Queries.GetTalentoEsportivoByAluno;
using DnaBrasilApi.Application.Common.Models;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoByVocacional;
using DnaBrasilApi.Application.Laudos.Queries.GetDesempenhoByAluno;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosByFilter;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Laudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateLaudo)
            .MapPut(UpdateEncaminhamentoTalentoEsportivo, "Encaminhamento/TalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoTalentoEsportivoV1, "v1/Encaminhamento/TalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoSaudeBucal, "Encaminhamento/SaudeBucal/{alunoId}")
            .MapPut(UpdateEncaminhamentoVocacional, "Encaminhamento/Vocacional/{alunoId}")
            .MapPut(UpdateEncaminhamentoQualidadeDeVida, "Encaminhamento/QualidadeDeVida/{alunoId}")
            .MapPut(UpdateEncaminhamentoConsumoAlimentar, "Encaminhamento/ConsumoAlimentar/{alunoId}")
            .MapGet(GetLaudosAll)
            .MapGet(GetLaudoByAluno, "Aluno/{id}")
            .MapGet(GetTalentoEsportivoByAlunoQuery, "TalentoEsportivo/Aluno/{id}")
            .MapGet(GetEncaminhamentoBySaudeId, "Encaminhamento/Saude/{id}")
            .MapGet(GetEncaminhamentoByQualidadeDeVidaId, "Encaminhamento/QualidadeDeVida/{id}")
            .MapGet(GetEncaminhamentoByVocacional, "Encaminhamentos/Vocacional")
            .MapGet(GetDesempenhoByAluno, "Desempenho/{id}")
            .MapPost(GetLaudosByFilter, "Filter");
    }
    public async Task<int> CreateLaudo(ISender sender, CreateLaudoCommand command)
    {
        return await sender.Send(command);
    }
    public async Task<bool> UpdateEncaminhamentoTalentoEsportivo(ISender sender, int alunoId)
    {
        var result = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(alunoId));
        return result;
    }
    public async Task<bool> UpdateEncaminhamentoTalentoEsportivoV1(ISender sender, int alunoId, UpdateEncaminhamentoTalentoEsportivoV1Command command)
    {
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> UpdateEncaminhamentoVocacional(ISender sender, int alunoId, UpdateEncaminhamentoVocacionalCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> UpdateEncaminhamentoQualidadeDeVida(ISender sender, int alunoId, UpdateEncaminhamentoQualidadeDeVidaCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> UpdateEncaminhamentoConsumoAlimentar(ISender sender, int alunoId, UpdateEncaminhamentoConsumoAlimentarCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<bool> UpdateEncaminhamentoSaudeBucal(ISender sender, int alunoId, UpdateEncaminhamentoSaudeBucalCommand command)
    {
        if (alunoId != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }
    public async Task<PaginatedList<LaudoDto>> GetLaudosAll(ISender sender, [AsParameters] GetLaudosAllQuery query)
    {
        return await sender.Send(query);
    }
    public async Task<LaudoDto> GetLaudoByAluno(ISender sender, int id)
    {
        var laudo = await sender.Send(new GetLaudoByAlunoQuery(id));
        return laudo;
    }
    public async Task<EncaminhamentoDto> GetEncaminhamentoBySaudeId(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentoBySaudeIdQuery(id));
    }
    public async Task<TalentoEsportivoDto> GetTalentoEsportivoByAlunoQuery(ISender sender, int id)
    {
        return await sender.Send(new GetTalentoEsportivoByAlunoQuery(id));
    }
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentoByQualidadeDeVidaId(ISender sender, int id)
    {
        return await sender.Send(new GetEncaminhamentoByQualidadeDeVidaIdQuery(id));
    }
    public async Task<List<EncaminhamentoDto>> GetEncaminhamentoByVocacional(ISender sender)
    {
        return await sender.Send(new GetEncaminhamentoByVocacionalQuery());
    }
    public async Task<DesempenhoDto> GetDesempenhoByAluno(ISender sender, int id)
    {
        return await sender.Send(new GetDesempenhoByAlunoQuery(id));

    }
    public async Task<LaudosFilterDto> GetLaudosByFilter(ISender sender, [FromBody] LaudosFilterDto search)
    {
        var result = await sender.Send(new GetLaudosByFilterQuery() { SearchFilter = search });

        search.Laudos = result;

        return search;
    }
}
