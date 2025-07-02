using DnaBrasilApi.Application.Common.Interfaces;

namespace DnaBrasilApi.Application.Alunos.Commands.UpdateProfileAluno;

public record UpdateProfileAlunoCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string? Email { get; init; }
    public string? Telefone { get; init; }
    public string? Celular { get; init; }
    public string? Cep { get; init; }
    public string? Endereco { get; init; }
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
}

public class UpdateProfileAlunoCommandHandler : IRequestHandler<UpdateProfileAlunoCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateProfileAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProfileAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Alunos
            .FindAsync([request.Id], cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Email = request.Email!;
        entity.Cep = request.Cep;
        entity.Telefone = request.Telefone;
        entity.Celular = request.Celular;
        entity.Endereco = request.Endereco;
        entity.Numero = request.Numero;
        entity.Bairro = request.Bairro;

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result >= 1;//true
    }
}
