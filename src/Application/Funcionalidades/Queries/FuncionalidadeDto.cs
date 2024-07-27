using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Funcionalidades.Queries;
public class FuncionalidadeDto
{
    public int Id { get; set; }
    public  string? Nome { get; set; }
    public  string? NomeModulo { get; set; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Funcionalidade, FuncionalidadeDto>()
                .ForMember(dest => dest.NomeModulo, opt => opt.MapFrom(src => src.Modulo!.Nome));
        }
    }
}
