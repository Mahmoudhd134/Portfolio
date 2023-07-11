using AutoMapper;

namespace AllLogic.Helpers;

public class AutoMapperProfiler : Profile
{
    public AutoMapperProfiler()
    {
        CreateMap<AddProjectDto, Project>();
        CreateMap<Project,ProjectDto>();
        CreateMap<EditProjectDto,Project>();
        CreateMap<Project,ProjectForListDto>();
    }
}