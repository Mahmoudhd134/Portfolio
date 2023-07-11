using AllLogic.data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AllLogic.MediatR.Commands.ProjectCommands;

public record AddProjectCommand(AddProjectDto AddProjectDto) : IRequest<Response<bool>>;

public class AddProjectHandler : IRequestHandler<AddProjectCommand, Response<bool>>
{
    private readonly IdentityContext _context;
    private readonly IMapper _mapper;

    public AddProjectHandler(IdentityContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<bool>> Handle(AddProjectCommand request, CancellationToken cancellationToken)
    {
        var sameNameFound =
           await _context.Projects.AnyAsync(p => p.Name.ToLower().Equals(request.AddProjectDto.Name.ToLower()),
                cancellationToken);
        
        if(sameNameFound)
            return Response<bool>.Failure(ProjectErrors.SameNameFound(request.AddProjectDto.Name));

        var project = _mapper.Map<Project>(request.AddProjectDto);
        _context.Projects.Add(project);
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}