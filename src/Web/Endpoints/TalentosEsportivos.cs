using DnaBrasilApi.Application.Laudos.Commands.CreateTalentoEsportivo;
using DnaBrasilApi.Application.Laudos.Commands.UpdateTalentoEsportivo;

namespace DnaBrasilApi.Web.Endpoints;

public class TalentosEsportivos : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(CreateTalentoEsportivo);
            //.MapPut(UpdateTalentoEsportivo, "{id}");
    }

    public async Task<int> CreateTalentoEsportivo(ISender sender, CreateTalentoEsportivoCommand command)
    {
        return await sender.Send(command);
    }

    //public async Task<bool> UpdateTalentoEsportivo(ISender sender, int id, UpdateTalentoEsportivoCommand command)
    //{
    //    if (id != command.Id) return false;
    //    var result = await sender.Send(command);
    //    return result;
    //}

}
