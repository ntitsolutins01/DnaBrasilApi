using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Ambientes.Queries;
public class AmbienteDto
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<AlunoDto> Alunos { get; } = new();
    public List<ProfissionalDto> Profissionais { get; } = new();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Ambiente, AmbienteDto>();
        }
    }
}
