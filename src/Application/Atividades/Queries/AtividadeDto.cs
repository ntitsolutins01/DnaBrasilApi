using DnaBrasilApi.Application.Categorias.Queries;
using DnaBrasilApi.Application.Estruturas.Queries;
using DnaBrasilApi.Application.LinhasAcoes.Queries;
using DnaBrasilApi.Application.Localidades.Queries;
using DnaBrasilApi.Application.Modalidades.Queries;
using DnaBrasilApi.Application.Profissionais.Queries;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Queries;

public class AtividadeDto
{
    public required int Id { get; init; }
    public required EstruturaDto Estrutura { get; init; }
    public required LinhaAcaoDto LinhaAcao { get; init; }
    public required CategoriaDto Categoria { get; init; }
    public required ModalidadeDto Modalidade { get; init; }
    public string? Turma { get; init; }
    public DateTime? HrIni { get; init; }
    public DateTime? HrFim { get; init; }
    public required ProfissionalDto Profissional { get; init; }
    public required LocalidadeDto Localidade { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Atividade, AtividadeDto>();
        }
    }
}
