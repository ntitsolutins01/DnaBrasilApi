using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Ardalis.GuardClauses;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries.ProcessarGabarito;

public record ProcessarGabaritoCommand : IRequest<Dictionary<string, object>>
{
    public byte[]? ByteImage { get; init; }
}

public class ProcessarGabaritoCommandHandler : IRequestHandler<ProcessarGabaritoCommand, Dictionary<string, object>>
{
    private readonly IApplicationDbContext _context;
    private readonly HttpClient _httpClient;

    public ProcessarGabaritoCommandHandler(IApplicationDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<Dictionary<string, object>> Handle(ProcessarGabaritoCommand request, CancellationToken cancellationToken)
    {
        if (request.ByteImage is null)
            throw new Exception("Imagem não fornecida.");

        using var content = new MultipartFormDataContent();
        var imageContent = new ByteArrayContent(request.ByteImage);
        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

        var response = await _httpClient.PostAsync("http://localhost:5050/corrigir", content, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;

        return data;
    }
}
