using DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalById;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Profissionais.Commands.CreateProfissional;
using DnaBrasilApi.Application.Profissionais.Commands.DeleteProfissional;
using DnaBrasilApi.Application.Profissionais.Commands.UpdateProfissional;
using DnaBrasilApi.Application.Profissionais.Queries.GetProfissionaisAll;
using DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByCpfCnpj;
using DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByEmail;
using DnaBrasilApi.Application.Profissionais.Queries.GetProfissionalByLocalidade;

namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Profissionais
/// </summary>
public class Profissionais : EndpointGroupBase
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
            .MapGet(GetProfissionaisAll)
            .MapPost(CreateProfissional)
            .MapPut(UpdateProfissional, "{id}")
            .MapDelete(DeleteProfissional, "{id}")
            .MapGet(GetProfissionalById, "Profissional/{id}")
            .MapGet(GetProfissionalByEmail, "Email/{email}")
            .MapGet(GetProfissionalByCpfCnpj, "Cpf/{cpf}")
            .MapGet(GetProfissionaisByLocalidade, "Localidade/{id}");
    }
    #endregion

    #region Main Methods

    /// <summary>
    /// Endpoint para inclusão de Profissionais
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Profissionais</param>
    /// <returns>Retorna Id de novo Profissionais</returns>
    public async Task<int> CreateProfissional(ISender sender, CreateProfissionalCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Profissionais
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Profissionais</param>
    /// <param name="command">Objeto de alteração de Profissionais</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateProfissional(ISender sender, int id, UpdateProfissionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    /// <summary>
    /// Endpoint para exclusão de Profissionais
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de exclusão de Profissionais</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> DeleteProfissional(ISender sender, int id)
    {
        return await sender.Send(new DeleteProfissionalCommand(id));
    }
    #endregion

    #region Get Methods

    /// <summary>
    /// Endpoint que busca todos os Profissionaiss cadastrados
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <returns>Retorna a lista de Profissionais</returns>
    public async Task<List<ProfissionalDto>> GetProfissionaisAll(ISender sender)
    {
        return await sender.Send(new GetProfissionaisAllQuery());
    }

    /// <summary>
    /// Endpoint que busca um único Profissional
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id do profissional a ser buscado</param>
    /// <returns>Retorna o objeto da Profissional </returns>
    public async Task<ProfissionalDto> GetProfissionalById(ISender sender, int id)
    {
        return await sender.Send(new GetProfissionalByIdQuery() { Id = id });
    }
    /// <summary>
    /// Endpoint que busca o Profissional por Email
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="email">email</param>
    /// <returns>retorna um Profissional por Email</returns>
    public async Task<ProfissionalDto> GetProfissionalByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetProfissionalByEmailQuery() { Email = email });
    }
    /// <summary>
    /// Endpoint que busca um Profissional por Cpf e Cnpj
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="cpfCnpj">cpfcnpj</param>
    /// <returns>retorna um Profissional por Cpf e Cnpj</returns>
    public async Task<ProfissionalDto> GetProfissionalByCpfCnpj(ISender sender, string cpfCnpj)
    {
        return await sender.Send(new GetProfissionalByCpfCnpjQuery() { CpfCnpj = cpfCnpj });
    }

    /// <summary>
    /// Endpoint que busca uma lista de Profissionais por Localidade
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="id">id da localidade</param>
    /// <returns>retrona uma lista de profissionais</returns>
    public async Task<List<ProfissionalDto>> GetProfissionaisByLocalidade(ISender sender, int id)
    {
        return await sender.Send(new GetProfissionalByLocalidadeQuery() { LocalidadeId = id });
    }
    #endregion
}
