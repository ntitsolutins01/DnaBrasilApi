using DnaBrasil.Application.Common.Interfaces;
using DnaBrasil.Application.TodoItems.Commands.CreateTodoItem;
using DnaBrasil.Domain.Entities;
using DnaBrasil.Domain.Events;

namespace DnaBrasil.Application.Alunos.Commands.CreateAluno;

public record CreateAlunoCommand : IRequest<int>
{
    public string? Nome { get; init; }
    public string? Email { get; init; }
    public string? Sexo { get; init; }
    public DateTime DtNascimento { get; init; }
    public string? NomeMae { get; init; }
    public string? NomePai { get; init; }
    public string? Cpf { get; init; }
    public string? Telefone { get; init;}
    public string? Celular { get; init;}
    public string? Cep { get; init;}
    public string? Endereco { get; init;}
    public string? Numero { get; init; }
    public string? Bairro { get; init; }
    public string? RedeSocial { get; init; }
    public string? Url { get; init;}
    public bool Status { get; init;}
    public bool Habilitado { get; init;}
}

public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateAlunoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        var entity = new Aluno
        {
            Nome = request.Nome,
            Email = request.Email,
            Sexo = request.Sexo,
            DtNascimento = request.DtNascimento,
            NomeMae = request.NomeMae,
            NomePai = request.NomePai,
            Cpf = request.Cpf,
            Telefone = request.Telefone,
            Celular = request.Celular,
            Endereco = request.Endereco,
            Numero = request.Numero,
            Bairro = request.Bairro,
            RedeSocial = request.RedeSocial,
            Url = request.Url,
            Status = request.Status,
            Habilitado = request.Habilitado
        };

        entity.AddDomainEvent(new AlunoCreatedEvent(entity));

        _context.Alunos.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
