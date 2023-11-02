using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class LaudoDto
{
    public TalentoEsportivo? TalentoEsportivo { get; set; }
    public Vocacional? Vocacional { get; set; }
    public QualidadeDeVida? QualidadeDeVida { get; set; }
    public Saude? Saude { get; set; }
    public ConsumoAlimentar? Consumo { get; set; }
    public SaudeBucal? SaudeBucal { get; set; }
    public required AlunoDto Aluno { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoDto>();
        }
    }
}
