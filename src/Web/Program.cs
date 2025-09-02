using System.Net.Http.Headers;
using DnaBrasilApi.Application;
using DnaBrasilApi.Infrastructure;
using DnaBrasilApi.Infrastructure.Data;
using DnaBrasilApi.Web;

var builder = WebApplication.CreateBuilder(args);

//Log4net
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

// Habilita CORS para todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Configura a ApiPython para processar gabaritos
var pythonApiBaseUrl = builder.Configuration["PythonApi:BaseUrl"]
                       ?? throw new InvalidOperationException("PythonApi:BaseUrl não configurada.");

builder.Services.AddHttpClient("PythonApi", client =>
{
    client.BaseAddress = new Uri(pythonApiBaseUrl);
    client.Timeout = TimeSpan.FromSeconds(60);
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

// Ativa o CORS
app.UseCors("AllowAll");

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options => { });

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

namespace DnaBrasilApi.Web
{
    public partial class Program { }
}
