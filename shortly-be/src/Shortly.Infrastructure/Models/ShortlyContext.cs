using Microsoft.EntityFrameworkCore;

namespace Shortly.Infrastructure.Models;

public partial class ShortlyContext : DbContext
{
    public ShortlyContext()
    {
    }

    public ShortlyContext(DbContextOptions<ShortlyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ShortUrlMapping> UrlMappings { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseNpgsql("Server=localhost:5432;Database=shortly;User Id=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortUrlMapping>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("url_mapping_pkey");

            entity.ToTable("url_mapping", "shortly");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("creation_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("true")
                .HasColumnName("is_active");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
