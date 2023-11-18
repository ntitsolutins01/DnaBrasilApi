using DnaBrasilApi.Application.TipoLaudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Questionarios.Queries;

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
