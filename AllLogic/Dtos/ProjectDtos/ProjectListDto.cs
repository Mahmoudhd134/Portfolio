namespace AllLogic.Dtos.ProjectDtos;

public class ProjectListDto
{
    public int CurrentPageIndex { get; set; }
    public int MaxPageIndex { get; set; }
    public bool HasNext { get; set; }
    public IEnumerable<ProjectForListDto> Projects { get; set; }
}