using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllLogic.EntityConfiguration;

public class ProjectConfiguration:IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
        builder.Property(p => p.Introduction).HasMaxLength(1023).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(4095).IsRequired();
    }
}