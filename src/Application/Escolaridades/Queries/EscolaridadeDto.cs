using DnaBrasil.Application.Alunos.Queries;
using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Escolaridades.Queries;
public class EscolaridadeDto
{
    public string? Nome { get; set; }
    public bool Status { get; set; }
    public List<AlunoDto> Alunos { get; } = new();
    public List<ProfissionalDto> Profissionais { get; } = new();
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Escolaridade, EscolaridadeDto>();
        }
    }
}
