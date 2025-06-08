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
    private readonly HttpClient _httpClient = new HttpClient();

    public ProcessarGabaritoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Dictionary<string, object>> Handle(ProcessarGabaritoCommand request, CancellationToken cancellationToken)
    {
        if (request.ByteImage is null)
            throw new Exception("Imagem não fornecida.");

        var base64Image = Convert.ToBase64String(request.ByteImage);

        var body = new { image = base64Image };

        var jsonContent = new StringContent(
            JsonSerializer.Serialize(body),
            System.Text.Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("http://localhost:5050/corrigir", jsonContent, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;

        return data;
    }
}
