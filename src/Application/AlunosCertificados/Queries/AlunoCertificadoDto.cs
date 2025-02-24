using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.AlunosCertificados.Queries;

public class AlunoCertificadoDto
{
    public required int Id { get; init; }
    public required int AlunoId { get; init; }
    public required int CertificadoId { get; init; }
    public DateTimeOffset? Created { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCertificado, AlunoCertificadoDto>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created));
        }
    }
}
