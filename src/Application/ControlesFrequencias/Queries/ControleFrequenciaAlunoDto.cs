using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesFrequencias.Queries;
public class ControleFrequenciaAlunoDto
{
    public int AlunoId { get; set; }
    public required string NomeAluno { get; set; }
    public string? MunicipioEstado { get; set; }
    public string? NomeLocalidade { get; set; }
    public int LocalidadeId { get; set; }
    public int MunicipioId { get; set; }
    public byte[]? ByteImage { get; set; }
    public List<ControlesFrequenciasDto>? ControlesFrequencias { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleFrequencia, ControleFrequenciaAlunoDto>()
                .ForMember(dest => dest.AlunoId, opt => opt.MapFrom(src => src.Aluno.Id))
                .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
                .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Aluno.Municipio.Id))
                .ForMember(dest => dest.MunicipioEstado,
                    opt => opt.MapFrom(src =>
                        src.Aluno.Municipio.Nome!.ToString() + " / " + src.Aluno.Municipio.Estado!.Sigla!.ToString()))
                .ForMember(dest => dest.LocalidadeId, opt => opt.MapFrom(src => src.Aluno.Localidade.Id))
                .ForMember(dest => dest.NomeLocalidade, opt => opt.MapFrom(src => src.Aluno.Localidade.Nome))
                .ForMember(dest => dest.ControlesFrequencias, opt => opt.MapFrom(src => new List<ControlesFrequenciasDto> {
                    new ControlesFrequenciasDto
                    {
                        Id = src.Id,
                        DisciplinaId = src.Disciplina.Id,
                        Presenca = src.Presenca,
                        Justificativa = src.Justificativa,
                        Data = src.Created.ToString("dd/MM/yyyy"),
                        Status = src.Status
                    }
                })); ;
        }
    }
}

