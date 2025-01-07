using DnaBrasilApi.Application.Certificados.Queries.GetCertificadoById;
using DnaBrasilApi.Application.Certificados.Commands.CreateCertificado;
using DnaBrasilApi.Application.Certificados.Commands.DeleteCertificado;
using DnaBrasilApi.Application.Certificados.Commands.UpdateCertificado;
using DnaBrasilApi.Application.Certificados.Queries;
using DnaBrasilApi.Application.Certificados.Queries.GetCertificadosAll;

namespace DnaBrasilApi.Web.Endpoints;

public class Certificados : EndpointGroupBase
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
            .MapGet(GetCertificadosAll)
            .MapPost(CreateCertificado)
            .MapPut(UpdateCertificado, "{id}")
            .MapDelete(DeleteCertificado, "{id}")
            .MapGet(GetCertificadoById, "Certificado/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Certificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão da Certificado</param>
    /// <returns>Retorna Id da nova Certificado</returns>
    public async Task<int> CreateCertificado(ISender sender, CreateCertificadoCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Certificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração da Certificado</param>
    /// <param name="command">Objeto de alteração da Certificado</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateCertificado(ISender sender, int id, UpdateCertificadoCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Certificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusao da Certificado</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteCertificado(ISender sender, int id)
    {
        return await sender.Send(new DeleteCertificadoCommand(id));
    }

    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todas as Certificados cadastradas
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Certificados</returns>
    public async Task<List<CertificadoDto>> GetCertificadosAll(ISender sender)
    {
        return await sender.Send(new GetCertificadosAllQuery());
    }

    /// <summary>
    /// Endpoint que busca uma única Certificado
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id da Certificado a ser buscada</param>
    /// <returns>Retorna o objeto da Certificado </returns>
    public async Task<CertificadoDto> GetCertificadoById(ISender sender, int id)
    {
        return await sender.Send(new GetCertificadoByIdQuery() { Id = id });
    }
    #endregion

}
