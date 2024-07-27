using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.LinhasAcoes.Queries;

public class LinhaAcaoDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public bool Status { get; set; } = true;


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<LinhaAcao, LinhaAcaoDto>();
        }
    }
}
