using DnaBrasilApi.Application.Laudos.Commands.CreateVocacional;
using DnaBrasilApi.Application.Laudos.Commands.UpdateVocacional;
using DnaBrasilApi.Application.Laudos.Queries.GetSaudeById;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetVocacionalById;

namespace DnaBrasilApi.Web.Endpoints;

public class Vocacionais : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetVocacionalById, "{id}")
            .MapPost(CreateVocacional)
            .MapPut(UpdateVocacional, "{id}");
    }
    #endregion


    #region Main Methods

    public async Task<int> CreateVocacional(ISender sender, CreateVocacionalCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateVocacional(ISender sender, int id, UpdateVocacionalCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }
    #endregion

    #region Methods
    public async Task<VocacionalDto> GetVocacionalById(ISender sender, int id)
    {
        return await sender.Send(new GetVocacionalByIdQuery() { Id = id });
    }
    #endregion

}
