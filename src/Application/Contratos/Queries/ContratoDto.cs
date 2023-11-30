using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Contratos.Queries;
public class ContratoDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Descricao { get; init; }
    public required DateTime DtIni { get; set; }
    public required DateTime DtFim { get; set; }
    public string? Anexo { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contrato, ContratoDto>();
        }
    }
}
