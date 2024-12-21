using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Atividades.Commands.CreateAtividade;
public record CreateAtividadeCommand : IRequest<int>
{
    public required int EstruturaId { get; set; }
    public required int LinhaAcaoId { get; set; }
    public required int CategoriaId { get; set; }
    public required int ModalidadeId { get; set; }
    public string? Turma { get; set; }
    public DateTime? HrIni { get; set; }
    public DateTime? HrFim { get; set; }
    public required int ProfissionalId { get; set; }
    public required int LocalidadeId { get; set; }
}

public class CreateAtividadeCommandHandler : IRequestHandler<CreateAtividadeCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAtividadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAtividadeCommand request, CancellationToken cancellationToken)
    {
        var estrutura = await _context.Estruturas
            .FindAsync(new object[] { request.EstruturaId }, cancellationToken);

        Guard.Against.NotFound(request.EstruturaId, estrutura);

        var linhaAcao = await _context.LinhasAcoes
            .FindAsync(new object[] { request.LinhaAcaoId }, cancellationToken);

        Guard.Against.NotFound(request.LinhaAcaoId, linhaAcao);

        var categoria = await _context.Categorias
            .FindAsync(new object[] { request.CategoriaId }, cancellationToken);

        Guard.Against.NotFound(request.CategoriaId, categoria);

        var modalidade = await _context.Modalidades
            .FindAsync(new object[] { request.ModalidadeId }, cancellationToken);

        Guard.Against.NotFound(request.ModalidadeId, modalidade);

        var profissional = await _context.Profissionais
            .FindAsync(new object[] { request.ProfissionalId }, cancellationToken);

        Guard.Against.NotFound(request.ProfissionalId, profissional);

        var localidade = await _context.Localidades
            .FindAsync(new object[] { request.LocalidadeId }, cancellationToken);

        Guard.Against.NotFound(request.LocalidadeId, localidade);

        var entity = new Atividade
        {
            Estrutura = estrutura,
            LinhaAcao = linhaAcao,
            Categoria = categoria,
            Modalidade = modalidade,
            Turma = request.Turma,
            HrIni = request.HrIni,
            HrFim = request.HrFim,
            Profissional = profissional,
            Localidade = localidade
        };

        _context.Atividades.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
