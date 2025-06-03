//using DnaBrasilApi.Application.Common.Interfaces;

//namespace DnaBrasilApi.Application.Alunos.Commands.DeleteAlunoCurso;

//public record DeleteAlunoCursoCommand : IRequest<bool>
//{
//    public required int AlunoId { get; init; }
//}

//public class DeleteAlunoCursoCommandHandler : IRequestHandler<DeleteAlunoCursoCommand, bool>
//{
//    private readonly IApplicationDbContext _context;
//    private readonly IMapper _mapper;

//    public DeleteAlunoCursoCommandHandler(IApplicationDbContext context, IMapper mapper)
//    {
//        _context = context;
//        _mapper = mapper;
//    }

//    public async Task<bool> Handle(DeleteAlunoCursoCommand request, CancellationToken cancellationToken)
//    {
//        var list = await _context.AlunosCursos
//            .Where(x => x.AlunoId == request.AlunoId)
//            .AsNoTracking()
//            .ToListAsync(cancellationToken);

//        _context.AlunosCursos.RemoveRange(list);

//        var result = await _context.SaveChangesAsync(cancellationToken);

//        return result >= 1;
//    }
//}
