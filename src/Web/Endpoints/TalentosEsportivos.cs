using DnaBrasilApi.Application.Common.Exceptions;
using DnaBrasilApi.Application.Laudos.Commands.UpdateEncaminhamentoTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Commands.CreateTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Commands.UpdateTalentoEsportivo;
using DnaBrasilApi.Application.TalentosEsportivos.Queries;
using DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoByAluno;
using DnaBrasilApi.Application.TalentosEsportivos.Queries.GetTalentoEsportivoById;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Web.Endpoints;

public class TalentosEsportivos : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateTalentoEsportivo)
            .MapPut(UpdateTalentoEsportivo, "{id}")
            .MapGet(GetTalentoEsportivoByIdQuery, "{id}")
            .MapGet(GetTalentoEsportivoByAlunoQuery, "Aluno/{alunoId}");
    }

    #endregion

    #region Main Methods
    public async Task<int> CreateTalentoEsportivo(ISender sender, CreateTalentoEsportivoCommand command)
    {
        var result = await sender.Send(command);

        var updateResult = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(command.AlunoId));

        return result;
    }

    public async Task<bool> UpdateTalentoEsportivo(ISender sender, int id, UpdateTalentoEsportivoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        var updateResult = await sender.Send(new UpdateEncaminhamentoTalentoEsportivoCommand(command.AlunoId));

        return result;
    }
    #endregion

    #region Methods

    public async Task<TalentoEsportivoDto> GetTalentoEsportivoByAlunoQuery(ISender sender, int alunoId)
    {
        return await sender.Send(new GetTalentoEsportivoByAlunoQuery(alunoId));
    }
    public async Task<TalentoEsportivoDto> GetTalentoEsportivoByIdQuery(ISender sender, int id)
    {
        return await sender.Send(new GetTalentoEsportivoByIdQuery(id));
    }
    #endregion

}
