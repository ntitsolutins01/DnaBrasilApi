using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.PlanosAulas.Queries;
public class PlanoAulaDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? TipoEscolaridade { get; set; }
    public string? Url { get; set; }
    public string? NomeArquivo { get; set; }
    public string? Modalidade { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PlanoAula, PlanoAulaDto>();
        }
    }
}
