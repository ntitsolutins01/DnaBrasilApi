using DnaBrasilApi.Application.Respostas.Queries;
using DnaBrasilApi.Application.TipoLaudos.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Questionarios.Queries;

public class QuestionarioDto
{
    public int Id { get; init; }
    public required string Pergunta { get; init; }
    public required TipoLaudoDto TipoLaudo { get; init; }
    public List<RespostaDto>? Respostas { get; init; }
    public required int Quadrante { get; init; }
    public required int Questao { get; init; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Questionario, QuestionarioDto>();
        }
    }
}
