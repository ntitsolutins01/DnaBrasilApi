using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.TalentosEsportivos.Queries;
public class TalentoEsportivoDto
{
    public int Id { get; init; }
    public int ProfissionalId { get; init; }
    public decimal? Flexibilidade { get; init; }
    public decimal? PreensaoManual { get; init; }
    public decimal? Velocidade { get; init; }
    public decimal? ImpulsaoHorizontal { get; init; }
    public decimal? Vo2Max { get; init; }
    public decimal? Abdominal { get; init; }
    public decimal? Imc { get; init; }
    public decimal? ShuttleRun { get; init; }
    public string? Encaminhamento { get; init; }
    public decimal? Altura { get; init; }
    public decimal? Peso { get; init; }
    public decimal? Envergadura { get; init; }
    public int AlunoId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TalentoEsportivo, TalentoEsportivoDto>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno!.Id))
                .ForMember(dest => dest.ProfissionalId, opt => opt.MapFrom(src => src.Profissional.Id));
        }
    }
}
