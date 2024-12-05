using DnaBrasilApi.Application.Laudos.Commands.CreateSaude;
using DnaBrasilApi.Application.Laudos.Commands.UpdateSaude;
using DnaBrasilApi.Application.Laudos.Queries;
using DnaBrasilApi.Application.Laudos.Queries.GetSaudeById;


namespace DnaBrasilApi.Web.Endpoints;

public class Saudes : EndpointGroupBase
{
    #region MapEndpoints
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateSaude)
            .MapPut(UpdateSaude, "{id}")
            .MapGet(GetSaudeById, "{id}");
    }
    #endregion


    #region Main Methods
    public async Task<int> CreateSaude(ISender sender, CreateSaudeCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateSaude(ISender sender, int id, UpdateSaudeCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

    #endregion

    #region Methods

    public async Task<SaudeDto> GetSaudeById(ISender sender, int id)
    {
        return await sender.Send(new GetSaudeByIdQuery() { Id = id });
    }
    #endregion

}
