namespace MicroVideosCatalog.Infrastructure.Data.Mapping;
public class VideoMap : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        builder.ToTable("videos", "dbo");

        builder.Property(p => p.Title)
                .HasMaxLength(120)
                .IsRequired();

        builder.Property(p => p.Description)
                .HasMaxLength(1000)
                .IsRequired();

        builder.Property(p => p.YearLaunched)
                .HasMaxLength(4)
                .IsRequired();

        builder.Property(p => p.Opened)
                .HasMaxLength(1)
                .IsRequired();

        builder.Property(p => p.Rating)
                .HasMaxLength(10);

        builder.Property(p => p.Duration)
                .HasMaxLength(10)
                .IsRequired();

        builder.HasMany(p => p.Categories);
        builder.HasMany(p => p.Genres);
        builder.HasMany(p => p.CastMembers);
        builder.HasMany(p => p.VideoFiles);
    }
}