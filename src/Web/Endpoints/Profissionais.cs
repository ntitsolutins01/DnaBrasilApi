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

public class Profissionais : EndpointGroupBase
{
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

    public async Task<List<ProfissionalDto>> GetProfissionaisAll(ISender sender)
    {
        return await sender.Send(new GetProfissionaisAllQuery());
    }

    public async Task<ProfissionalDto> GetProfissionalById(ISender sender, int id)
    {
        return await sender.Send(new GetProfissionalByIdQuery() { Id = id });
    }

    public async Task<int> CreateProfissional(ISender sender, CreateProfissionalCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateProfissional(ISender sender, int id, UpdateProfissionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteProfissional(ISender sender, int id)
    {
        return await sender.Send(new DeleteProfissionalCommand(id));
    }
    public async Task<ProfissionalDto> GetProfissionalByEmail(ISender sender, string email)
    {
        return await sender.Send(new GetProfissionalByEmailQuery() { Email = email });
    }
    public async Task<ProfissionalDto> GetProfissionalByCpfCnpj(ISender sender, string cpfCnpj)
    {
        return await sender.Send(new GetProfissionalByCpfCnpjQuery() { CpfCnpj = cpfCnpj });
    }
    public async Task<List<ProfissionalDto>> GetProfissionaisByLocalidade(ISender sender, int id)
    {
        return await sender.Send(new GetProfissionalByLocalidadeQuery() { LocalidadeId = id });
    }
}
