﻿using DnaBrasilApi.Application.Common.Interfaces;

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

        _context.Localidades.Remove(entity);

        var result = await _context.SaveChangesAsync(cancellationToken);
        return result == 1;
    }

}
