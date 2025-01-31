using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Queries;

public class AtividadeAlunoDto
{
    public required int Id { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Atividade, AtividadeDto>();
        }
    }
}
