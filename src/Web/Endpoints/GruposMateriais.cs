using DnaBrasilApi.Application.GruposMateriais.Commands.CreateGrupoMaterial;
using DnaBrasilApi.Application.GruposMateriais.Commands.DeleteGrupoMaterial;
using DnaBrasilApi.Application.GruposMateriais.Commands.UpdateGrupoMaterial;
using DnaBrasilApi.Application.GruposMateriais.Queries;
using DnaBrasilApi.Application.GruposMateriais.Queries.GetGrupoMaterialById;
using DnaBrasilApi.Application.GruposMateriais.Queries.GetGruposMateriaisAll;

namespace DnaBrasilApi.Web.Endpoints;

public class GruposMateriais : EndpointGroupBase
{
    #region MapEndpoints

    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetGruposMateriaisAll)
            .MapPost(CreateGrupoMaterial)
            .MapPut(UpdateGrupoMaterial, "{id}")
            .MapDelete(DeleteGrupoMaterial, "{id}")
            .MapGet(GetGrupoMaterialById, "GrupoMaterial/{id}");
    }

    #endregion

    #region Main Methods

    public async Task<int> CreateGrupoMaterial(ISender sender, CreateGrupoMaterialCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateGrupoMaterial(ISender sender, int id, UpdateGrupoMaterialCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    public async Task<bool> DeleteGrupoMaterial(ISender sender, int id)
    {
        return await sender.Send(new DeleteGrupoMaterialCommand(id));
    }

    #endregion

    #region Methods

    public async Task<List<GrupoMaterialDto>> GetGruposMateriaisAll(ISender sender)
    {
        return await sender.Send(new GetGruposMateriaisAllQuery());
    }

    public async Task<GrupoMaterialDto> GetGrupoMaterialById(ISender sender, int id)
    {
        return await sender.Send(new GetGrupoMaterialByIdQuery() { Id = id });
    }

    #endregion
}
