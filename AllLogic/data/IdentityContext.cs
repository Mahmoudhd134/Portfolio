using AllLogic.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AllLogic.data;

public class IdentityContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ProjectsSkill> ProjectsSkills { get; set; }
    public DbSet<Image> Images { get; set; }
    
    public IdentityContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new ProjectsSkillConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}