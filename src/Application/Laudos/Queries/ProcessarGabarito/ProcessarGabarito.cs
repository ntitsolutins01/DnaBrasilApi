using System.Text;
using System.Text.Json;

namespace DnaBrasilApi.Application.Laudos.Queries.ProcessarGabarito;

public record ProcessarGabaritoCommand : IRequest<Dictionary<string, object>>
{
    public byte[]? ByteImage { get; init; }
}

public class ProcessarGabaritoCommandHandler
    : IRequestHandler<ProcessarGabaritoCommand, Dictionary<string, object>>
{
    private readonly HttpClient _httpClient;

    public ProcessarGabaritoCommandHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("PythonApi");
    }

    public async Task<Dictionary<string, object>> Handle(ProcessarGabaritoCommand request, CancellationToken cancellationToken)
    {
        var payload = new { image = Convert.ToBase64String(request.ByteImage!) };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/corrigir", content, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<Dictionary<string, object>>(json)!;
    }
}
