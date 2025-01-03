using DnaBrasilApi.Application.Alunos.Commands.CreateAluno;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoAmbientes;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoFoto;
using DnaBrasilApi.Application.Alunos.Commands.UpdateQrCode;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoByEmail;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoById;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByLocalidade;
using DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosAll;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

/// <summary>
/// Api de Alunos
/// </summary>
public class Alunos : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            //.MapGet(GetAlunosByFilter)
            .MapGet(GetAlunoById, "Aluno/{id}")
            .MapGet(GetAlunoByEmail, "Aluno/Email/{email}")
            .MapGet(GetAlunosByLocalidade, "/Localidade/{id}")
            .MapGet(GetNomeAlunosAll, "/NomeAlunos/{id}")
            .MapGet(GetAlunosAll)
            .MapPost(CreateAluno)
            .MapPut(UpdateAluno, "{id}")
            .MapPut(UpdateAlunoFoto, "/UploadFoto/{id}")
            .MapPut(UpdateAlunoModalidades, "/Modalidades")
            .MapPut(UpdateQrCode, "/QrCode/{id}")
            .MapDelete(DeleteAluno, "{id}")
            .MapPost(GetAlunosByFilter, "Filter");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Aluno</param>
    /// <returns>Retorna Id de novo Aluno</returns>
    public async Task<int> CreateAluno(ISender sender, CreateAlunoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Aluno</param>
    /// <param name="command">Objeto de alteração de Aluno</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAluno(ISender sender, int id, UpdateAlunoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Qr Code
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Qr Code</param>
    /// <param name="command">Objeto de alteração de Qr Code</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateQrCode(ISender sender, int id, UpdateQrCodeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Aluno Foto
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Aluno Foto</param>
    /// <param name="command">Objeto de alteração de Aluno Foto</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAlunoFoto(ISender sender, int id, UpdateAlunoFotoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para alteração de Aluno Modalidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Aluno Modalidade</param>
    /// <param name="command">Objeto de alteração de Aluno Modalidade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<IResult> UpdateAlunoModalidades(ISender sender, UpdateAlunoModalidadesCommand command)
    {
        await sender.Send(command);

        return Results.NoContent();
    }

    /// <summary>
    /// Endpoint para exclusão de Aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Aluno</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAluno(ISender sender, int id)
    {
        return await sender.Send(new DeleteAlunoCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca Alunos por Filtro 
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="search">filtro para pesquisas de Alunos</param>
    /// <returns>retorna a lista de Alunos</returns>
    public async Task<AlunosFilterDto> GetAlunosByFilter(ISender sender, [FromBody] AlunosFilterDto search)
    {
        var result = await sender.Send(new GetAlunosByFilterQuery() { SearchFilter = search });

        return new AlunosFilterDto { Alunos = result };
    }

    /// <summary>
    /// Endpoint que busca um único Aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Aluno a ser buscado</param>
    /// <returns>Retorna o objeto de Aluno</returns>
    public async Task<AlunoDto> GetAlunoById(ISender sender, int id)
    {
        return await sender.Send(new GetAlunoByIdQuery() { Id = id });
    }
    /// <summary>
    /// Endpoint que busca Alunos por Email
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="email">email</param>
    /// <returns>Retorna uma lista de Email</returns>
    public async Task<AlunoDto> GetAlunoByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetAlunoByEmailQuery() { Email = email });
    }

    /// <summary>
    /// Endpoint que busca todos os Alunos cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Alunos</returns>
    public async Task<List<AlunoDto>> GetAlunosAll(ISender sender)
    {
        return await sender.Send(new GetAlunosAllQuery());
    }
    /// <summary>
    /// Endpoint que busca Alunos por Localidade
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id por Localidade</param>
    /// <returns>Retorna a uma localidade</returns>
    public async Task<List<AlunoIndexDto>> GetAlunosByLocalidade(ISender sender, int id)
    {
        return await sender.Send(new GetAlunosByLocalidadeQuery { LocalidadeId = id });
    }

    /// <summary>
    /// Endpoint que busca Todos Nomes de Alunos
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id de todos os Alunos</param>
    /// <returns>Retorna todos os Alunos</returns>
    public async Task<List<SelectListDto>> GetNomeAlunosAll(ISender sender, string id)
    {
        return await sender.Send(new GetNomeAlunosAllQuery() { LocalidadeId = id });
    }
    #endregion
}
