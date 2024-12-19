using DnaBrasilApi.Application.Encaminhamentos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class ConsumoAlimentarDto
{
    public required int Id { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public EncaminhamentoDto? Encaminhamento { get; init; }
    public required string Respostas { get; init; }
    public string? StatusConsumoAlimentar { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ConsumoAlimentar, ConsumoAlimentarDto>();
        }
    }
}
