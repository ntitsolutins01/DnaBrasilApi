using DnaBrasilApi.Application.DocumentosAluno.Commands.CreateDocumentoAluno;
using DnaBrasilApi.Application.DocumentosAluno.Commands.DeleteDocumentoAluno;
using DnaBrasilApi.Application.DocumentosAluno.Queries;
using DnaBrasilApi.Application.DocumentosAluno.Queries.GetDocumentoAlunoById;
using DnaBrasilApi.Application.DocumentosAluno.Queries.GetDocumentosAllByAlunoId;

namespace DnaBrasilApi.Web.Endpoints;

public class DocumentosAluno : EndpointGroupBase
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
            .MapGet(GetDocumentosAllByalunoId, "/Aluno/{alunoId}")
            .MapPost(CreateDocumentoAluno)
            .MapDelete(DeleteDocumentoAluno, "{id}")
            .MapGet(GetDocumentoAlunoById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Documentos do aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de documentos</param>
    /// <returns>Retorna quantidade de documentos inseridos</returns>
    public async Task<int> CreateDocumentoAluno(ISender sender, List<CreateDocumentoAlunoDto> list)
    {
        var listDocumentoIds = new List<int>();

        foreach (var item in list)
        {
            var command = new CreateDocumentoAlunoCommand()
            {
                AlunoId = item.AlunoId,
                NomeDocumento = item.NomeDocumento,
                Url = item.Url
            };

            var idDocumento = await sender.Send(command);

            listDocumentoIds.Add(idDocumento);
        }

        return listDocumentoIds.Count;
    }

    /// <summary>
    /// Endpoint para exclusão de documento do aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de documento do aluno </param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteDocumentoAluno(ISender sender, int id)
    {
        return await sender.Send(new DeleteDocumentoAlunoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Documentos do aluno cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="alunoId">Id do aluno</param>
    /// <returns>Retorna a lista de Documentos do aluno</returns>
    public async Task<List<DocumentoAlunoDto>> GetDocumentosAllByalunoId(ISender sender, int alunoId)
    {
        return await sender.Send(new GetDocumentosAllByAlunoIdQuery() { AlunoId = alunoId });
    }

    /// <summary>
    /// Endpoint que busca um único documento do aluno
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do documento do aluno a ser buscado</param>
    /// <returns>Retorna o objeto do documento do aluno </returns>
    public async Task<DocumentoAlunoDto> GetDocumentoAlunoById(ISender sender, int id)
    {
        return await sender.Send(new GetDocumentoAlunoByIdQuery() { Id = id });
    }
    #endregion

}
