using DnaBrasilApi.Application.Dashboards.Queries;
using DnaBrasilApi.Application.Dashboards.Queries.GetControlePresencaByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetIndicadoresAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetLaudosAlunosByFilter;
using DnaBrasilApi.Application.Dashboards.Queries.GetLaudosPeriodo;
using DnaBrasilApi.Application.Dashboards.Queries.GetPercentualSaudeAlunos;
using DnaBrasilApi.Application.Dashboards.Queries.GetStatusLaudosAll;
using DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorDeficienciaAlunos;
using DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorDesempenhoAlunos;
using DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorEtniaAlunos;
using DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorSaudeSexoAlunos;
using DnaBrasilApi.Application.Dashboards.Queries.GetTotalizadorTalentoEsportivoAlunos;
using Microsoft.AspNetCore.Mvc;

namespace DnaBrasilApi.Web.Endpoints;

public class Dashboards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapPost(GetValida,"valida")
            .MapPost(GetIndicadoresAlunosByFilter, "Indicadores")
            .MapPost(GetControlePresencaByFilter, "ControlePresenca")
            .MapPost(GetLaudosPeriodoByFilter, "LaudosPeriodo")
            .MapPost(GetStatusLaudosByFilter, "StatusLaudos")
            .MapPost(GetEvolutivoByFilter, "Evolutivo")
            .MapPost(GetGraficosPizzaBarraByFilter,"GraficosPizzaBarra");
    }

    public async Task<DashboardDto> GetIndicadoresAlunosByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.AlunosCadastrados = await sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard });

        dashboard.Sexo = "F";
        dashboard.CadastrosFemininos = await sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "M";
        dashboard.CadastrosMasculinos = await sender.Send(new GetIndicadoresAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "";

        dashboard.StatusLaudo = "A";
        dashboard.LaudosAndamentos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.StatusLaudo = "F";
        dashboard.LaudosFinalizados = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.StatusLaudo = "";

        dashboard.Sexo = "F";
        dashboard.LaudosFemininos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "M";
        dashboard.LaudosMasculinos = await sender.Send(new GetLaudosAlunosByFilterQuery() { SearchFilter = dashboard });
        dashboard.Sexo = "";


        return await Task.FromResult(dashboard);
    }
    public async Task<DashboardDto> GetControlePresencaByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.Controle = "P";
        dashboard.ListPresencasAnual = await sender.Send(new GetControlePresencaByFilterQuery() { SearchFilter = dashboard });
        dashboard.Controle = "F";
        dashboard.ListFaltasAnual = await sender.Send(new GetControlePresencaByFilterQuery() { SearchFilter = dashboard });

        return await Task.FromResult(dashboard);
    }
    public async Task<DashboardDto> GetLaudosPeriodoByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        var laudosPeriodo = await sender.Send(new GetLaudosPeriodoQuery() { SearchFilter = dashboard });

        dashboard.Ultimos3Meses = laudosPeriodo[0];
        dashboard.Ultimos6Meses = laudosPeriodo[1];
        dashboard.Em1Ano = laudosPeriodo[2];

        return await Task.FromResult(dashboard);
    }
    public async Task<DashboardDto> GetStatusLaudosByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.StatusLaudos = await sender.Send(new GetStatusLaudosAllQuery());

        return await Task.FromResult(dashboard);
    }
    public async Task<DashboardDto> GetEvolutivoByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        //dashboard.StatusLaudos = await sender.Send(new GetEvolutivoByFilter());

        return await Task.FromResult(dashboard);
    }
    public async Task<DashboardDto> GetGraficosPizzaBarraByFilter(ISender sender, [FromBody] DashboardDto dashboard)
    {
        dashboard.PercentualSaude = await sender.Send(new GetPercentualSaudeAlunosQuery() { SearchFilter = dashboard });
        dashboard.ListTotalizadorSaudeSexo = await sender.Send(new GetTotalizadorSaudeSexoAlunosQuery() { SearchFilter = dashboard });

        dashboard.ListTotalizadorTalento =
            await sender.Send(new GetTotalizadorTalentoEsportivoAlunosQuery() { SearchFilter = dashboard });

        dashboard.ListTotalizadorDesempenho = 
            await sender.Send(new GetTotalizadorDesempenhoAlunosQuery() { SearchFilter = dashboard });

        dashboard.ListTotalizadorDeficiencia = 
            await sender.Send(new GetTotalizadorDeficienciaAlunosQuery() { SearchFilter = dashboard });

        dashboard.ListTotalizadorEtnia =
            await sender.Send(new GetTotalizadorEtniaAlunosQuery() { SearchFilter = dashboard });

        return await Task.FromResult(dashboard);
    }


    public async Task<TotalizadorEtniaDto> GetValida(ISender sender, [FromBody] DashboardDto dashboard)
    {
        return await sender.Send(new GetTotalizadorEtniaAlunosQuery() { SearchFilter = dashboard });
    }
}
