using DnaBrasilApi.Application.Alunos.Commands.CreateAluno;
using DnaBrasilApi.Application.Alunos.Commands.CreateAlunoCertificados;
using DnaBrasilApi.Application.Alunos.Commands.CreateAlunoCursos;
using DnaBrasilApi.Application.Alunos.Commands.CreateAlunoPresencas;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAluno;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoCertificado;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoCurso;
using DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoModalidade;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAluno;
using DnaBrasilApi.Application.Alunos.Commands.UpdateAlunoFoto;
using DnaBrasilApi.Application.Alunos.Commands.UpdateQrCode;
using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoAulasByAlunoId;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoByEmail;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunoById;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosCursosByCursoId;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosAll;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByFilter;
using DnaBrasilApi.Application.Alunos.Queries.GetAlunosByLocalidade;
using DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosAll;
using DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosByLocalidadeId;
using DnaBrasilApi.Application.Alunos.Queries.GetNomeAlunosByProfissionalId;
using DnaBrasilApi.Application.Alunos.Queries.GetPresencasByAlunoId;
using DnaBrasilApi.Application.Alunos.Queries.GetPresencasByDataAtividadeId;
using DnaBrasilApi.Application.Atividades.Queries;
using DnaBrasilApi.Application.Aulas.Queries;
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
            .MapGet(GetAlunoById, "{id}")
            .MapGet(GetAlunoByEmail, "/Email/{email}")
            .MapGet(GetAlunosByLocalidade, "/Localidade/{id}")
            .MapGet(GetNomeAlunosAll, "/NomeAlunos")
            .MapGet(GetNomeAlunosByLocalidadeId, "/NomeAlunos/Localidade/{id}")
            .MapGet(GetAlunosAll)
            .MapPost(CreateAluno)
            .MapPost(CreateAlunoCursos, "Cursos")
            .MapPost(CreateAlunoCertificados, "Certificados")
            .MapPost(CreateAlunoPresencas, "Presencas")
            .MapPut(UpdateAluno, "{id}")
            .MapPut(UpdateAlunoCertificado, "{id}/Certificados")
            .MapPut(UpdateAlunoCurso, "{id}/Cursos")
            .MapPut(UpdateAlunoFoto, "/UploadFoto/{id}")
            .MapPut(UpdateQrCode, "/QrCode/{id}")
            .MapDelete(DeleteAluno, "{id}")
            .MapPost(GetAlunosByFilter, "Filter")
            .MapGet(GetAlunosCursosByCursoId, "AlunoCurso/{cursoId}")
            .MapGet(GetPresencasByDataAtividadeId, "/Presenca/{data}/{id}")
            .MapGet(GetNomeAlunosByProfissionalId, "/Profissional/{id}")
            .MapGet(GetAlunoAulasByAlunoId, "AlunoAula/{alunoId}");
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
        await sender.Send(new DeleteAlunoModalidadeCommand() { AlunoId = id });
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para inclusão de Aluno e Curso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Aluno e seus Curso</param>
    /// <returns>Retorna Id da Aluno</returns>
    public async Task<int> CreateAlunoCursos(ISender sender, CreateAlunoCursoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para inclusão de Aluno e Certificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Aluno e seus Certificado</param>
    /// <returns>Retorna Id da Aluno</returns>
    public async Task<int> CreateAlunoCertificados(ISender sender, CreateAlunoCertificadoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para inclusão de Aluno e Presenca
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Aluno e suas Presencas</param>
    /// <returns>Retorna Id da Aluno</returns>
    public async Task<int> CreateAlunoPresencas(ISender sender, CreateAlunoPresencaCommand command)
    {
        return await sender.Send(command);
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
    /// Endpoint para exclusão de Aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Aluno</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAluno(ISender sender, int id)
    {
        return await sender.Send(new DeleteAlunoCommand(id));
    }

    /// <summary>
    /// Endpoint para alteração de Aluno e Cursos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Aluno</param>
    /// <param name="command">Objeto de alteração da AlunoCurso</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAlunoCurso(ISender sender, int id, CreateAlunoCursoCommand command)
    {
        if (id != command.AlunoId) return false;
        await sender.Send(new DeleteAlunoCursoCommand() { AlunoId = id });
        var result = await sender.Send(command);
        return result > 0;
    }

    /// <summary>
    /// Endpoint para alteração de Aluno e Certificados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Aluno</param>
    /// <param name="command">Objeto de alteração da AlunoCertificado</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAlunoCertificado(ISender sender, int id, CreateAlunoCertificadoCommand command)
    {
        if (id != command.AlunoId) return false;
        await sender.Send(new DeleteAlunoCertificadoCommand() { AlunoId = id });
        var result = await sender.Send(command);
        return result > 0;
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
    /// <returns>Retorna todos os nomes dos alunos para uma combo</returns>
    public async Task<List<SelectListDto>> GetNomeAlunosAll(ISender sender)
    {
        return await sender.Send(new GetNomeAlunosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca Todos Nomes de Alunos
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">Id da localidade dos alunos</param>
    /// <returns>Retorna todos os nomes dos alunos para uma combo</returns>
    public async Task<List<SelectListDto>> GetNomeAlunosByLocalidadeId(ISender sender, int id)
    {
        return await sender.Send(new GetNomeAlunosByLocalidadeIdQuery() { LocalidadeId = id });
    }

    /// <summary>
    /// Endpoint que busca Todos Nomes de Alunos pelo id do profissional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do profissional</param>
    /// <returns>Retorna todos os Alunos</returns>
    public async Task<List<SelectListDto>> GetNomeAlunosByProfissionalId(ISender sender, int id)
    {
        return await sender.Send(new GetNomeAlunosByProfissionalIdQuery() { ProfissionalId = id });
    }

    /// <summary>
    /// Endpoint que busca uma lista de presencas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do aluno</param>
    /// <returns>Retorna uma lista de presencas</returns>
    public async Task<List<AtividadeDto>> GetPresencasByAlunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetPresencasByAlunoIdQuery() { AlunoId = alunoId });
    }

    /// <summary>
    /// Endpoint que busca uma lista de presenças dos alunos por data e atividade 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="data">Data da presença</param>
    /// <param name="id">Id da atividade</param>
    /// <returns>Retorna uma lista de presencas</returns>
    public async Task<List<AtividadeDto>> GetPresencasByDataAtividadeId(ISender sender, string data, int id)
    {
        return await sender.Send(new GetPresencasByDataAtividadeIdQuery() { Data = data, AtividadeId = id});
    }

    /// <summary>
    /// Endpoint que busca um AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do aluno</param>
    /// <returns>Retorna um AlunoCurso</returns>
    public async Task<List<AlunoCursoDto>> GetAlunosCursosByCursoId(ISender sender, int cursoId)
    {
        return await sender.Send(new GetAlunosCursosByCursoIdQuery() { CursoId = cursoId });
    }

    /// <summary>
    /// Endpoint que busca um AlunoCurso
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do aluno</param>
    /// <returns>Retorna um AlunoCurso</returns>
    public async Task<List<AlunoAulaDto>> GetAlunoAulasByAlunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetAlunoAulasByAlunoIdQuery() { AlunoId = alunoId });
    }
    #endregion
}
