using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllLogic.EntityConfiguration;

public class ImageConfiguration:IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name).HasMaxLength(511).IsRequired();
        builder.Property(i => i.StoredName).HasMaxLength(1023).IsRequired();

        builder
            .HasOne(i => i.Project)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.ProjectId);
    }
}