using DnaBrasilApi.Application.QuestoesEad.Commands.CreateQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.DeleteQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Commands.UpdateQuestaoEad;
using DnaBrasilApi.Application.QuestoesEad.Queries;
using DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestaoEadById;
using DnaBrasilApi.Application.QuestoesEad.Queries.GetQuestoesEadAll;
using DnaBrasilApi.Application.RespostasEad.Commands.CreateRespostaEad;
using DnaBrasilApi.Application.TextosImagensQuestoes.Commands.CreateTextoImagemQuestao;

namespace DnaBrasilApi.Web.Endpoints;

public class QuestoesEad : EndpointGroupBase
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
            .MapGet(GetQuestoesEadAll)
            .MapPost(CreateQuestaoEad)
            .MapPut(UpdateQuestaoEad, "{id}")
            .MapDelete(DeleteQuestaoEad, "{id}")
            .MapGet(GetQuestaoEadById, "{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Questões Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Questões Ead</param>
    /// <returns>Retorna Id de nova Questões Ead</returns>
    public async Task<int> CreateQuestaoEad(ISender sender, QuestaoEadModel questaoEadModel)
    {
        var questaoId = await sender.Send(new CreateQuestaoEadCommand()
        {
            AulaId = questaoEadModel.AulaId,
            NumeroQuestao = questaoEadModel.NumeroQuestao,
            Enunciado = questaoEadModel.Enunciado,
            Referencia = questaoEadModel.Referencia
        });

        if (questaoEadModel.ListImagens != null)
        {
            foreach (var item in questaoEadModel.ListImagens)
            {
                await sender.Send(new CreateTextoImagemQuestaoCommand()
                {
                    QuestaoEadId = questaoId,
                    Ordem = item.First().Key,
                    TextoImagem = item.First().Value,
                    Tipo = "I"
                });
            }
        }

        if (questaoEadModel.ListTextos != null)
        {
            foreach (var item in questaoEadModel.ListTextos)
            {
                await sender.Send(new CreateTextoImagemQuestaoCommand()
                {
                    QuestaoEadId = questaoId,
                    Ordem = item.First().Key,
                    TextoImagem = item.First().Value,
                    Tipo = "T"
                });
            }
        }

        if (questaoEadModel.Respostas != null)
        {
            foreach (var item in questaoEadModel.Respostas)
            {
                await sender.Send(new CreateRespostaEadCommand
                {
                    QuestaoId = questaoId,
                    TipoResposta = item.TipoResposta,
                    Resposta = item.Resposta,
                    ValorPesoResposta = item.ValorPesoResposta,
                    RespostaCerta = item.RespostaCerta
                });
            }
        }

        return questaoId;
    }

    /// <summary>
    /// Endpoint para alteração de Questões Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Questões Ead</param>
    /// <param name="command">Objeto de alteração de Questões Ead</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateQuestaoEad(ISender sender, int id, UpdateQuestaoEadCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Questões Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao de Questões Ead</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteQuestaoEad(ISender sender, int id)
    {
        return await sender.Send(new DeleteQuestaoEadCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Questões Eads cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Questões Eads</returns>
    public async Task<List<QuestaoEadDto>> GetQuestoesEadAll(ISender sender)
    {
        return await sender.Send(new GetQuestoesEadAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Questão Ead
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de Questões Ead a ser buscada</param>
    /// <returns>Retorna o objeto de Questões Ead </returns>
    public async Task<QuestaoEadDto> GetQuestaoEadById(ISender sender, int id)
    {
        return await sender.Send(new GetQuestaoEadByIdQuery() { Id = id });
    }
    #endregion
}
