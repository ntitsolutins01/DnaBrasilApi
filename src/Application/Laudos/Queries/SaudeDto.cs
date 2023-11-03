using DnaBrasil.Application.Profissionais.Queries;
using DnaBrasil.Domain.Entities;

namespace DnaBrasil.Application.Laudos.Queries;
public class SaudeDto
{
    public int Id { get; init; }
    public required ProfissionalDto Profissional { get; set; }
    public int? Altura { get; set; }
    public int Massa { get; set; }
    public int? Envergadura { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Saude, SaudeDto>();
        }
    }
}
