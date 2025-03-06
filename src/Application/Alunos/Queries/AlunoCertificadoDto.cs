using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoCertificadoDto
{
    public required string AlunoId { get; init; }
    public required string CertificadoId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCertificado, AlunoCertificadoDto>();
        }
    }
}
