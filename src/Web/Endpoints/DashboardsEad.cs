using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.DashboardsEad;
using DnaBrasilApi.Application.DashboardsEad.Queries;
using DnaBrasilApi.Application.DashboardsEad.Queries.GetIndicadoresEadAlunosByFilter;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class DashboardsEad : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(GetIndicadoresEadAlunosByFilter, "IndicadoresEad");
    }

    public async Task<DashboardEadDto> GetIndicadoresEadAlunosByFilter(ISender sender, [FromBody] DashboardEadDto DashboardEad)
    {
        DashboardEad.AlunosCadastrados = await sender.Send(new GetIndicadoresEadAlunosByFilterQuery() { SearchFilter = DashboardEad });

        DashboardEad.Sexo = "F";
        DashboardEad.CadastrosFemininos = await sender.Send(new GetIndicadoresEadAlunosByFilterQuery() { SearchFilter = DashboardEad });
        DashboardEad.Sexo = "M";
        DashboardEad.CadastrosMasculinos = await sender.Send(new GetIndicadoresEadAlunosByFilterQuery() { SearchFilter = DashboardEad });
        DashboardEad.Sexo = "";

        //DashboardEad.StatusLaudo = "A";
        //DashboardEad.LaudosAndamentos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = DashboardEad });
        //DashboardEad.StatusLaudo = "F";
        //DashboardEad.LaudosFinalizados = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = DashboardEad });
        //DashboardEad.StatusLaudo = "";

        //DashboardEad.AvaliacoesDna = DashboardEad.LaudosAndamentos + DashboardEad.LaudosFinalizados;

        //DashboardEad.Sexo = "F";
        //DashboardEad.LaudosFemininos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = DashboardEad });
        //DashboardEad.Sexo = "M";
        //DashboardEad.LaudosMasculinos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = DashboardEad });
        //DashboardEad.Sexo = "";


        return await Task.FromResult(DashboardEad);
    }

}
