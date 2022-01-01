namespace MicroVideosCatalog.Infrastructure.Data.Mapping;
public class GenreMap : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("genres", "dbo");

        builder.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

        builder.HasMany(p => p.Categories);
    }
}