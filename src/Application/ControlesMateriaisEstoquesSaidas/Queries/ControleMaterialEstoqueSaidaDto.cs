using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.ControlesMateriaisEstoquesSaidas.Queries;

public class ControleMaterialEstoqueSaidaDto
{
    public required int Id { get; init; }
    public required int MaterialId { get; init; }
    public required int Quantidade { get; init; }
    public String? Solicitante { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ControleMaterialEstoqueSaida, ControleMaterialEstoqueSaidaDto>();
        }
    }
}
