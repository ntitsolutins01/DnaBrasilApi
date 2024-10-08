using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class VocacionalDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public required QuestionarioDto Questionario { get; init; }
    public required string Resposta { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Vocacional, VocacionalDto>();
        }
    }
}
