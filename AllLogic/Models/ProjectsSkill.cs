namespace AllLogic.Models;

public class ProjectsSkill
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}