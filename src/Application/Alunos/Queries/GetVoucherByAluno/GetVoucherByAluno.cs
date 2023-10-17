using DnaBrasil.Application.Common.Interfaces;

namespace DnaBrasil.Application.Alunos.Queries.GetVoucherByAluno;

public record GetVoucherByAlunoQuery : IRequest<VoucherDto>
{
}

public class GetVoucherByAlunoQueryValidator : AbstractValidator<GetVoucherByAlunoQuery>
{
    public GetVoucherByAlunoQueryValidator()
    {
    }
}

public class GetVoucherByAlunoQueryHandler : IRequestHandler<GetVoucherByAlunoQuery, VoucherDto>
{
    private readonly IApplicationDbContext _context;

    public GetVoucherByAlunoQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<VoucherDto> Handle(GetVoucherByAlunoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
