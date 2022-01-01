namespace MicroVideosCatalog.Infrastructure.Data.Mapping;
public class CastMemberMap : IEntityTypeConfiguration<CastMember>
{
    public void Configure(EntityTypeBuilder<CastMember> builder)
    {
        builder.ToTable("castMembers", "dbo");

        builder.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

        builder.Property(p => p.CastMemberType)
                .HasMaxLength(10)
                .HasColumnType("VARCHAR")
                .IsRequired();
    }
}