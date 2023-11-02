using DnaBrasil.Application.TipoLaudos.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Questionarios.Queries;

public class QuestionarioDto
{
    public required string Pergunta { get; set; }
    public required TipoLaudoDto Tipo { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Questionario, QuestionarioDto>();
        }
    }
}
