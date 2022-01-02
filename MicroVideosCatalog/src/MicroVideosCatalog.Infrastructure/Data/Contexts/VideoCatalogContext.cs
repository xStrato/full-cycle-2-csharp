namespace MicroVideosCatalog.Infrastructure.Data.Contexts;
public class VideoCatalogContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<CastMember> CastMembers { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<VideoFile> VideoFiles { get; set; }

    public VideoCatalogContext(DbContextOptions<VideoCatalogContext> opts) : base(opts) { }
    protected override void OnModelCreating(ModelBuilder builder)
        => builder.ApplyConfigurationsFromAssembly(typeof(VideoCatalogContext).Assembly);
}