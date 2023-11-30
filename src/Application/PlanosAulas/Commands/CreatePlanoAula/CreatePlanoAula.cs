using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Domain.Entities;

namespace DnaBrasilApi.Application.PlanosAulas.Commands.CreatePlanoAula;
public record CreatePlanoAulaCommand : IRequest<int>
{
    public string? Nome { get; set; }
    public string? Grade { get; set; }
    public string? Url { get; set; }
}

public class CreatePlanoAulaCommandHandler : IRequestHandler<CreatePlanoAulaCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePlanoAulaCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlanoAulaCommand request, CancellationToken cancellationToken)
    {
        var entity = new PlanoAula
        {
            Nome = request.Nome,
            Grade = request.Grade,
            Url = request.Url
        };

        _context.PlanosAulas.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
