using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Laudos.Queries.GetTalentoEsportivoByAluno;
using DnaBrasil.Application.Laudos.Queries.SaudeBucalByAluno;
using DnaBrasil.Application.Laudos.Queries.SaudeByAluno;
using DnaBrasil.Application.Laudos.Queries.VocacionalByAluno;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class LaudoDto
{
    public TalentoEsportivoDto? TalentoEsportivo { get; set; }
    public VocacionalDto? Vocacional { get; set; }
    //public QualidadeDeVidaDto? QualidadeDeVida { get; set; }
    public SaudeDto? Saude { get; set; }
    public ConsumoAlimentarDto? ConsumoAlimentar { get; set; }
    public SaudeBucalDto? SaudeBucal { get; set; }
    public required AlunoDto Aluno { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Laudo, LaudoDto>();
        }
    }
}
