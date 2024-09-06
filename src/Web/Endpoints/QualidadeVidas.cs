using DnaBrasilApi.Application.Laudos.Commands.CreateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Commands.UpdateQualidadeVida;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetQualidadeDeVidasAll;
using DnaBrasilApi.Application.Modalidades.Queries.GetAmbientesAll;
using DnaBrasilApi.Application.Modalidades.Queries;

namespace DnaBrasilApi.Web.Endpoints;

public class QualidadeDeVidas : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetQualidadeDeVidasAll)
            .MapPost(CreateQualidadeDeVida)
            .MapPut(UpdateQualidadeDeVida, "{id}");

    }


    public async Task<List<QualidadeDeVidaDto>> GetQualidadeDeVidasAll(ISender sender)
    {
        return await sender.Send(new GetQualidadeDeVidasAllQuery());
    }

    public async Task<int> CreateQualidadeDeVida(ISender sender, CreateQualidadeDeVidaCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateQualidadeDeVida(ISender sender, int id, UpdateEncaminhamentoQualidadeDeVidaCommand command)
    {
        if (id != command.AlunoId) return false;
        var result = await sender.Send(command);
        return result;
    }

}
