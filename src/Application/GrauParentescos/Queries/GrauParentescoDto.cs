using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.GrauParentescos.Queries;
public class GrauParentescoDto
{
    public required int Id { get; init; }
    public required string Nome { get; init; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<GrauParentesco, GrauParentescoDto>();
        }
    }
}
