using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesPresencas.Queries;
public class ControlePresencaAlunoDto
{
    public int AlunoId { get; set; }
    public required string NomeAluno { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? NomeLocalidade { get; set; }
    public int LocalidadeId { get; set; }
    public int MunicipioId { get; set; }
    public byte[]? ByteImage { get; set; }
    public List<ControlesPresencasDto>? ControlesPresencas { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControlePresenca, ControlePresencaAlunoDto>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Aluno.Municipio.Id))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Aluno.Municipio.Nome!.ToString() + " / " + src.Aluno.Municipio.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
                .ForMember(dest => dest.ControlesPresencas, opt => opt.MapFrom(src => new List<ControlesPresencasDto> {
                    new ControlesPresencasDto
                    {
                        Id = src.Id,
                        EventoId = src.Evento != null ? src.Evento.Id : null,
                        Controle = src.Controle,
                        Justificativa = src.Justificativa,
                        Data = src.Created.ToString("dd/MM/yyyy"),
                        Status = src.Status
                    }
                })); ;
        }
    }
}

