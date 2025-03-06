using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Alunos.Queries;

public class AlunoCertificadoDto
{
    public required int AlunoId { get; init; }
    public required int CertificadoId { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AlunoCertificado, AlunoCertificadoDto>();
        }
    }
}
