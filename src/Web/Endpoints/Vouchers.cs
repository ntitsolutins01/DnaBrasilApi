using DnaBrasilApi.Application.Alunos.Commands.CreateVoucher;
using DnaBrasilApi.Application.Alunos.Commands.UpdateVoucher;


namespace DnaBrasilApi.Web.Endpoints;
/// <summary>
/// Api de Vouchers
/// </summary>
public class Vouchers : EndpointGroupBase
{

    /// <summary>
    /// Mapeamento dos Endpoints
    /// </summary>
    /// <param name="app">Objeto usado para configurar as rotas e os http pipelines</param>
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()

            .MapPost(CreateVoucher)
            .MapPut(UpdateVoucher, "{id}");

    }

    /// <summary>
    /// Endpoint para inclusão de Voucher
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="command">Objeto de inclusão de Voucher</param>
    /// <returns>Retorna Id de novo Voucher</returns>
    public async Task<int> CreateVoucher(ISender sender, CreateVoucherCommand command)
    {
        return await sender.Send(command);
    }

    /// <summary>
    /// Endpoint para alteração de Voucher
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="id">Id de alteração de Voucher</param>
    /// <param name="command">Objeto de alteração de Voucher</param>
    /// <returns>Retorna true ou false</returns>
    public async Task<bool> UpdateVoucher(ISender sender, int id, UpdateVoucherCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
