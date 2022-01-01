namespace MicroVideosCatalog.Infrastructure.Data.Mapping;
public class VideoFileMap : IEntityTypeConfiguration<VideoFile>
{
    public void Configure(EntityTypeBuilder<VideoFile> builder)
    {
        builder.ToTable("videoFiles", "dbo");

        builder.Property(p => p.Title)
                .HasMaxLength(120)
                .IsRequired();

        builder.Property(p => p.Duration)
                .HasMaxLength(10)
                .IsRequired();

        builder.Property(p => p.Url)
               .HasMaxLength(200);
    }
}