using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Application.Questionarios.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;
public class ConsumoAlimentarDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; set; }
    public required QuestionarioDto Questionario { get; set; }
    public required string Resposta { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ConsumoAlimentar, ConsumoAlimentarDto>();
        }
    }
}
