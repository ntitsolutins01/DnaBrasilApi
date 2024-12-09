using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class SaudeBucalDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public Encaminhamento? Encaminhamento { get; init; }
    public required string Respostas { get; init; }
    public string? StatusSaudeBucal { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SaudeBucal, SaudeBucalDto>();
        }
    }
}
