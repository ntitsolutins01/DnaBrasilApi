using DnaBrasilApi.Application.Alunos.Commands.CreateAluno;
using DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoAmbientes;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoDeficiencias;
using DnaBrasilApi.Application.Alunos.Commands.UpdateVoucher;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoById;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByLocalidade;
using DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosAll;
using DnaBrasilApi.Application.Escolaridades.Queries.GetEscolaridadesAll;
using DnaBrasilApi.Application.Localidades.Queries.GetLocalidadesByFomento;
using DnaBrasilApi.Application.Localidades.Queries;
using Microsoft.AspNetCore.Mvc;
using DnaBrasilApi.Application.Ambientes.Queries.GetAmbienteById;
using DnaBrasilApi.Application.Ambientes.Queries;

namespace DnaBrasilApi.Web.Endpoints;
public class Alunos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            //.MapGet(GetAlunosByFilter)
            .MapGet(GetAlunoById, "Aluno/{id}")
            .MapGet(GetAlunosByLocalidade, "/Localidade/{id}")
            .MapGet(GetNomeAlunosAll, "/NomeAlunos/{id}")
            .MapGet(GetAlunosAll)
            .MapPost(CreateAluno)
            .MapPut(UpdateAluno, "{id}")
            .MapPut(UpdateAlunoAmbientes, "/Ambientes")
            .MapDelete(DeleteAluno, "{id}")
            .MapPost(GetAlunosByFilter, "Filter");
    }


    public async Task<AlunosFilterDto> GetAlunosByFilter(ISender sender, [FromBody] AlunosFilterDto search)
    {
        var result = await sender.Send(new GetAlunosByFilterQuery() { SearchFilter = search });

        return new AlunosFilterDto{ Alunos = result};
    }
    public async Task<AlunoDto> GetAlunoById(ISender sender, int id)
    {
        return await sender.Send(new GetAlunoByIdQuery() { Id = id });
    }
    public async Task<List<AlunoDto>> GetAlunosAll(ISender sender)
    {
        return await sender.Send(new GetAlunosAllQuery());
    }

    public async Task<int> CreateAluno(ISender sender, CreateAlunoCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateAluno(ISender sender, int id, UpdateAlunoCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteAluno(ISender sender, int id)
    {
        await sender.Send(new DeleteAlunoCommand(id));
        return Results.NoContent();
    }
    public async Task<int> CreateVoucher(ISender sender, CreateVoucherCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<IResult> UpdateVoucher(ISender sender, int id, UpdateVoucherCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> UpdateAlunoDeficiencias(ISender sender, UpdateAlunoDeficienciasCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<IResult> UpdateAlunoAmbientes(ISender sender, UpdateAlunoAmbientesCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    public async Task<List<AlunoDto>> GetAlunosByLocalidade(ISender sender, int id)
    {
        return await sender.Send(new GetAlunosByLocalidadeQuery { LocalidadeId = id });
    }

    public async Task<List<SelectListDto>> GetNomeAlunosAll(ISender sender, string id)
    {
        return await sender.Send(new GetNomeAlunosAllQuery() { LocalidadeId = id });
    }
}
