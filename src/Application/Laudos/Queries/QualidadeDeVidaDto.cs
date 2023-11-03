using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Application.Questionarios.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class QualidadeDeVidaDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; set; }
    public required QuestionarioDto Questionario { get; set; }
    public required string Resposta { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QualidadeDeVida, QualidadeDeVidaDto>();
        }
    }
}
