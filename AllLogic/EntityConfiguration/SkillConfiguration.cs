using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllLogic.EntityConfiguration;

public class SkillConfiguration:IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).HasMaxLength(127).IsRequired();
        builder.Property(s => s.Description).HasMaxLength(4095).IsRequired();

        builder.HasIndex(s => s.Name).IsUnique();
    }
}