using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.DocumentosAluno.Queries;

public class DocumentoAlunoDto
{
    public required int Id { get; set; }
    public required string NomeAluno { get; set; }
    public required string NomeDocumento { get; set; }
    public required string Url { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DocumentoAluno, DocumentoAlunoDto>()
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome));
        }
    }
}
