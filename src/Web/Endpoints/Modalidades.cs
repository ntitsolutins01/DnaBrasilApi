using DnaBrasilApi.Application.Modalidades.Commands.CreateModalidade;
using DnaBrasilApi.Application.Modalidades.Commands.DeleteModalidade;
using DnaBrasilApi.Application.Modalidades.Commands.UpdateModalidade;
using DnaBrasilApi.Application.Modalidades.Queries;
using DnaBrasilApi.Application.Modalidades.Queries.GetModalidadeById;
using DnaBrasilApi.Application.Modalidades.Queries.GetAmbientesAll;
using DnaBrasilApi.Application.Modalidades.Queries.GetModalidadesByLinhaAcaoId;

namespace DnaBrasilApi.Web.Endpoints;

public class Modalidades : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetModalidadesAll)
            .MapPost(CreateModalidade)
            .MapPut(UpdateModalidade, "{id}")
            .MapDelete(DeleteModalidade, "{id}")
            .MapGet(GetModalidadeById, "Modalidade/{id}")
            .MapGet(GetModalidadesByLinhaAcaoId, "LinhaAcao/{id}");
    }

    public async Task<List<ModalidadeDto>> GetModalidadesAll(ISender sender)
    {
        return await sender.Send(new GetModalidadesQuery());
    }

    public async Task<ModalidadeDto> GetModalidadeById(ISender sender, int id)
    {
        return await sender.Send(new GetModalidadeByIdQuery() { Id = id });
    }
    public async Task<List<ModalidadeDto>> GetModalidadesByLinhaAcaoId(ISender sender, int id)
    {
        return await sender.Send(new GetModalidadesByLinhaAcaoIdQuery() { Id = id });
    }
    public async Task<int> CreateModalidade(ISender sender, CreateModalidadeCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateModalidade(ISender sender, int id, UpdateModalidadeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteModalidade(ISender sender, int id)
    {
        return await sender.Send(new DeleteModalidadeCommand(id));
    }
}
