using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoConsumoAlimentar;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoSaudeBucal;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivoV1;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudoByAluno;
using DnaBrasilApi.Application.Laudos.Queries.GetEncaminhamentoBySaudeId;
using DnaBrasilApi.Application.Laudos.Queries.GetTalentoEsportivoByAluno;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DnaBrasilApi.Web.Endpoints;

public class Laudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateLaudo)
            .MapPut(UpdateEncaminhamentoTalentoEsportivo, "EncaminhamentoTalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoTalentoEsportivoV1, "v1/EncaminhamentoTalentoEsportivo/{alunoId}")
            .MapPut(UpdateEncaminhamentoVocacional, "EncaminhamentoVocacional/{alunoId}")
            .MapPut(UpdateEncaminhamentoQualidadeDeVida, "EncaminhamentoQualidadeDeVida/{alunoId}")
            .MapPut(UpdateEncaminhamentoConsumoAlimentar, "EncaminhamentoConsumoAlimentar/{alunoId}")
            .MapPut(UpdateEncaminhamentoSaudeBucal, "EncaminhamentoSaudeBucal/{alunoId}")
            .MapGet(GetLaudosAll)
            .MapGet(GetLaudoByAluno, "Laudo/Aluno/{id}")
            .MapGet(GetTalentoEsportivoByAlunoQuery, "Laudo/TalentoEsportivo/Aluno/{id}")
            .MapGet(GetEncaminhamentoBySaudeId, "EncaminhamentoSaude/{id}");
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
    public async Task<List<LaudoDto>> GetLaudosAll(ISender sender)
    {
        return await sender.Send(new GetLaudosAllQuery());
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
}
