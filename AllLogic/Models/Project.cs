namespace AllLogic.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Introduction { get; set; }
    public string Description { get; set; }
    public IList<Image> Images { get; set; }
    public IList<ProjectsSkill> ProjectsSkills { get; set; }
}