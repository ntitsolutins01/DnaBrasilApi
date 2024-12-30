using DnaBrasilApi.Application.Alunos.Queries;
using DnaBrasilApi.Application.Common.Interfaces;
using DnaBrasilApi.Application.Modalidades.Queries;
using DnaBrasilApi.Domain.Entities;
using DnaBrasilApi.Domain.GuardClauses;
using Microsoft.EntityFrameworkCore;

namespace DnaBrasilApi.Application.Profissionais.Commands.DeleteProfissionalModalidade;

public record DeleteProfissionalModalidadeCommand : IRequest<bool>
{
    public required int ProfissionalId { get; init; }
    public required int ModalidadeId { get; init; }
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
        int result;

        //var entity = await _context.Profissionais
        //    //.Include(i => i.Modalidades)
        //    .Where(x => x.Id == request.ProfissionalId)
        //    //.ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
        //    .AsNoTracking()
        //    .FirstAsync(cancellationToken);

        //Guard.Against.NotFound(request.ProfissionalId, entity);

        //var modalidade = await _context.Modalidades
        //    //.Include(i=>i.Profissionais)
        //    .Where(x=>x.Id == request.ModalidadeId)
        //    //.ProjectTo<ModalidadeDto>(_mapper.ConfigurationProvider)
        //    .AsNoTracking()
        //    .FirstAsync(cancellationToken);

        //Guard.Against.NotFound(request.ModalidadeId, modalidade);

        //entity.Modalidades?.Remove(modalidade);

        //modalidade.Profissionais?.Remove(entity);

        //var entity = await _context.Profissionais
        //    .Include(i=>i.Modalidades)
        //    .Where(x => x.Id == request.ProfissionalId)
        //    .Select(s=>s.Modalidades)
        //    .ToListAsync(cancellationToken);

        //foreach (var obj in entity)
        //{
        //    entity.Remove(obj);
        //}

        result = await _context.SaveChangesAsync(cancellationToken);

        return result == 1;
    }

}
