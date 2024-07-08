using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.FotosEvento.Queries;

public class CreateFotoEventoDto
{
    public required int EventoId { get; set; }
    public required string NomeArquivo { get; set; }
    public required string Url { get; set; }

}
