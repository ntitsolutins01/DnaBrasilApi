using DnaBrasilApi.Application.Atividades.Commands.CreateAtividade;
using DnaBrasilApi.Application.Atividades.Commands.CreateAtividadeAluno;
using DnaBrasilApi.Application.Atividades.Commands.DeleteAtividade;
using DnaBrasilApi.Application.Atividades.Commands.DeleteAtividadeAluno;
using DnaBrasilApi.Application.Atividades.Commands.UpdateAtividade;
using DnaBrasilApi.Application.Atividades.Queries;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadeAlunosByAtividadeId;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadeById;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadeByLocalidadeId;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadeByModalidadeIdProfissionalIdTurma;
using DnaBrasilApi.Application.Atividades.Queries.GetAtividadesAll;
using DnaBrasilApi.Application.Atividades.Queries.GetTurmasByModalidadeIdProfissionalId;

namespace DnaBrasilApi.Web.Endpoints;

public class Atividades : EndpointGroupBase
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
            .MapPost(CreateAtividade)
            .MapPost(CreateAtividadeAlunos, "Alunos")
            .MapPut(UpdateAtividade, "{id}")
            .MapPut(UpdateAtividadeAluno, "{id}/Alunos")
            .MapDelete(DeleteAtividade, "{id}")
            .MapGet(GetAtividadesAll)
            .MapGet(GetAtividadeById, "{id}")
            .MapGet(GetAtividadeAlunosByAtividadeId, "{id}/Alunos")
            .MapGet(GetTurmasByModalidadeIdProfissionalId, "Modalidade/{modalidadeId}/Profissional/{profissionalId}")
            .MapGet(GetAtividadeByModalidadeIdProfissionalIdTurma, "Modalidade/{modalidadeId}/Profissional/{profissionalId}/Turma/{turma}")
            .MapGet(GetAtividadeByLocalidadeId, "Localidade/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Atividade</param>
    /// <returns>Retorna Id da nova Atividade</returns>
    public async Task<int> CreateAtividade(ISender sender, CreateAtividadeCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Atividade</param>
    /// <param name="command">Objeto de alteração da Atividade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAtividade(ISender sender, int id, UpdateAtividadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para inclusão de Atividade e Alunos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Atividade e seus Alunos</param>
    /// <returns>Retorna Id da Atividade</returns>
    public async Task<int> CreateAtividadeAlunos(ISender sender, CreateAtividadeAlunoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Atividade e Alunos
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Atividade</param>
    /// <param name="command">Objeto de alteração da AtividadeAlunos</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateAtividadeAluno(ISender sender, int id, CreateAtividadeAlunoCommand command)
    {
        if (id != command.AtividadeId) return false;
        await sender.Send(new DeleteAtividadeAlunoCommand() { AtividadeId = id });
        var result = await sender.Send(command);
        return result > 0;
    }

    /// <summary>
    /// Endpoint para exclusão de Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Atividade</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteAtividade(ISender sender, int id)
    {
        return await sender.Send(new DeleteAtividadeCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Atividades cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Atividades</returns>
    public async Task<List<AtividadeDto>> GetAtividadesAll(ISender sender)
    {
        return await sender.Send(new GetAtividadesAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Atividade a ser buscada</param>
    /// <returns>Retorna o objeto da Atividade </returns>
    public async Task<AtividadeDto> GetAtividadeById(ISender sender, int id)
    {
        return await sender.Send(new GetAtividadeByIdQuery() { Id = id });
    }

    /// <summary>
    /// Endpoint que busca lista de turmas pelo id da modalidade e id do profissional 
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="modalidadeId">Id da modalidade</param>
    /// <param name="profissionalId">Id do profissional</param>
    /// <returns>Retorna a lista de turmas</returns>
    public async Task<List<AtividadeDto>> GetTurmasByModalidadeIdProfissionalId(ISender sender, int modalidadeId, int profissionalId)
    {
        return await sender.Send(new GetTurmasByModalidadeIdProfissionalIdQuery() { ModalidadeId = modalidadeId, ProfissionalId = profissionalId });
    }

    /// <summary>
    /// Endpoint que busca atividade pelo id da modalidade, id do profissional e turma
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="modalidadeId">Id da modalidade</param>
    /// <param name="profissionalId">Id do profissional</param>
    /// <param name="turma">Turma do profissional</param>
    /// <returns>Retorna o objeto da Atividade</returns>
    public async Task<List<AtividadeDto>> GetAtividadeByModalidadeIdProfissionalIdTurma(ISender sender, int modalidadeId, int profissionalId, string turma)
    {
        return await sender.Send(new GetAtividadeByModalidadeIdProfissionalIdTurmaQuery() { ModalidadeId = modalidadeId, ProfissionalId = profissionalId, Turma = turma });
    }

    /// <summary>
    /// Endpoint que Alunos por Id da atividade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da atividade</param>
    /// <returns>Retorna a lista de atividades</returns>
    public async Task<List<AtividadeAlunoDto>> GetAtividadeAlunosByAtividadeId(ISender sender, int id)
    {
        return await sender.Send(new GetAtividadeAlunosByAtividadeIdQuery() { AtividadeId = id });
    }

    /// <summary>
    /// Endpoint que busca atividades por id da localidade
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da localidade</param>
    /// <returns>Retorna a lista de atividades</returns>
    public async Task<List<AtividadeDto>> GetAtividadeByLocalidadeId(ISender sender, int id)
    {
        return await sender.Send(new GetAtividadeByLocalidadeIdQuery() { LocalidadeId = id });
    }
    #endregion

}
