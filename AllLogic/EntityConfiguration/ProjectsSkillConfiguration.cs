using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllLogic.EntityConfiguration;

public class ProjectsSkillConfiguration:IEntityTypeConfiguration<ProjectsSkill>
{
    public void Configure(EntityTypeBuilder<ProjectsSkill> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Project)
            .WithMany(p => p.ProjectsSkills)
            .HasForeignKey(x => x.ProjectId);
        
        builder
            .HasOne(x => x.Skill)
            .WithMany(s => s.ProjectsSkills)
            .HasForeignKey(x => x.SkillId);
    }
}