using AllLogic.data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AllLogic.MediatR.Queries.ProjectQueries;

public record GetProjectByIdQuery(int Id) : IRequest<Response<ProjectDto>>;

public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, Response<ProjectDto>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public GetProjectByIdHandler(IdentityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<ProjectDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var project = await _context.Projects
            .Where(p => p.Id == id)
            .ProjectTo<ProjectDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
        
        return project ?? Response<ProjectDto>.Failure(ProjectErrors.WrongId(id));
    }
}