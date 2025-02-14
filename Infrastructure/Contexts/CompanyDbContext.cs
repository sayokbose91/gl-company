using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public partial class CompanyDbContext(DbContextOptions<CompanyDbContext> options) : DbContext(options)
{
    public virtual DbSet<Company> Companies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.HasIndex(e => e.Isin, "UQ_Companies_Isin").IsUnique();

            entity.Property(e => e.Exchange).HasMaxLength(100);
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Ticker).HasMaxLength(50);
            entity.Property(e => e.Website).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
