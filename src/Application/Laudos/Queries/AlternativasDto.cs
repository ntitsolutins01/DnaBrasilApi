using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Laudos.Queries;

public class AlternativasDto
{
    public int EducacionalId { get; init; }
    public required string Alternativas { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Educacional, AlternativasDto>();
        }
    }
}
