namespace MicroVideosCatalog.Infrastructure.Data.Mapping;
public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories", "dbo");

        builder.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();
    }
}