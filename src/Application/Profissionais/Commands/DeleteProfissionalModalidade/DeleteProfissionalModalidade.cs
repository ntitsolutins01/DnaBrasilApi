using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.Profissionais.Commands.DeleteProfissionalModalidade;

public record DeleteProfissionalModalidadeCommand : IRequest<bool>
{
    public required int ProfissionalId { get; init; }
}

public class DeleteProfissionalModalidadeCommandHandler : IRequestHandler<DeleteProfissionalModalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteProfissionalModalidadeCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteProfissionalModalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ProfissionalModalidades
            .Where(x => x.ProfissionalId == request.ProfissionalId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        foreach (ProfissionalModalidade obj in entity)
        {
            _context.ProfissionalModalidades.Remove(obj);
        }

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;
    }
}
