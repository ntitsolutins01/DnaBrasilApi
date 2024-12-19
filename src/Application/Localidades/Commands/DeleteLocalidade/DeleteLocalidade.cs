using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.GuardClauses;

namespace DnaBrasilApi.Application.Localidades.Commands.DeleteLocalidade;
public record DeleteLocalidadeCommand(int Id) : IRequest<bool>;

public class DeleteLocalidadeCommandHandler : IRequestHandler<DeleteLocalidadeCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteLocalidadeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteLocalidadeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Localidades
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        var possuiProfissionais = _context.Profissionais.Any(x => x.Localidade != null && x.Localidade.Id == request.Id);

        Guard.Against.PossuiProfissionais(possuiProfissionais);

        _context.Localidades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
