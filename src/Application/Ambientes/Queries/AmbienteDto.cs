using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Ambientes.Queries;
public class AmbienteDto
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Ambiente, AmbienteDto>();
        }
    }
}
