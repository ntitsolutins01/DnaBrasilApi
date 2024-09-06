using DnaBrasilApi.Application.Laudos.Commands.CreateLaudo;
using DnaBrasilApi.Application.Laudos.Commands.CreateSaude;
using DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoAlunos;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetLaudosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Laudos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateLaudo)
            .MapPut(UpdateEncaminhamentoAlunos, "EncaminhamentoAlunos")
            .MapPut(UpdateEncaminhamentoVocacional, "EncaminhamentoVocacional/{alunoId}")
            .MapPut(UpdateEncaminhamentoQualidadeDeVida, "EncaminhamentoQualidadeDeVida/{alunoId}")
            .MapGet(GetLaudosAll);
    }

    public async Task<int> CreateLaudo(ISender sender, CreateLaudoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateEncaminhamentoAlunos(ISender sender, UpdateEncaminhamentoAlunosCommand command)
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
    public async Task<List<LaudoDto>> GetLaudosAll(ISender sender)
    {
        return await sender.Send(new GetLaudosAllQuery());
    }
}
