using DnaBrasil.Application.Alunos.Commands.CreateVoucher;
using DnaBrasil.Application.Alunos.Commands.UpdateVoucher;
using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Vouchers.Commands.CreateVoucher;
using DnaBrasil.Application.Vouchers.Commands.DeleteVoucher;
using DnaBrasil.Application.Vouchers.Commands.UpdateVoucher;
using DnaBrasil.Application.Vouchers.Queries;
using DnaBrasil.Application.Vouchers.Queries.GetVouchersAll;

namespace DnaBrasil.Web.Endpoints;

public class Vouchers : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()

            .MapPost(CreateVoucher)
            .MapPut(UpdateVoucher, "{id}");

    }


    public async Task<int> CreateVoucher(ISender sender, CreateVoucherCommand command)
    {
        return await sender.Send(command);
    }

    public async Task<bool> UpdateVoucher(ISender sender, int id, UpdateVoucherCommand command)
    {
        if (id != command.Id) return false;
        var result = await sender.Send(command);
        return result;
    }

}
