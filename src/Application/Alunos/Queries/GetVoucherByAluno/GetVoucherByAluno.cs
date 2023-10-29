using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetVoucherByAluno;

public record GetVoucherByAlunoQuery : IRequest<List<VoucherDto>>
{
    public int AlunoId { get; set; }
}

public class GetVoucherByAlunoQueryHandler : IRequestHandler<GetVoucherByAlunoQuery, List<VoucherDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetVoucherByAlunoQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<VoucherDto>> Handle(GetVoucherByAlunoQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Alunos
            .Where(x => x.Id == request.AlunoId)
            .AsNoTracking()
            .ProjectTo<AlunoDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);


        return result!.Vouchers == null ? throw new ArgumentNullException(nameof(result.Vouchers)) : result.Vouchers;
    }
}
