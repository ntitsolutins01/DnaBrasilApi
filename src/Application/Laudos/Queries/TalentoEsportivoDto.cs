using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class TalentoEsportivoDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; set; }
    public int? Flexibilidade { get; set; }
    public int? PreensaoManual { get; set; }
    public int? Velocidade { get; set; }
    public int? ImpulsaoHorizontal { get; set; }
    public int? AptidaoFisica { get; set; }
    public int? Agilidade { get; set; }
    public int? Abdominal { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TalentoEsportivo, TalentoEsportivoDto>();
        }
    }
}
