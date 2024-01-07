using System.Globalization;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Fomentos.Queries;
public class FomentoDto
{
    public int Id { get; init; }
    public string? Codigo { get; init; }
    public string? Nome { get; init; }
    public required Municipio Municipio { get; init; }
    public required Localidade Localidade { get; init; }
    public string? Data { get; set; }
    public bool Status { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Fomentu, FomentoDto>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Created.ToString("dd/MM/yyyy")));
        }
    }

}
