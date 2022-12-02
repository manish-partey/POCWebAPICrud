using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using POCWebAPICrud.Models;

namespace POCWebAPICrud.Models;

public partial class PocDbContext : DbContext
{
  

    public PocDbContext(DbContextOptions<PocDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC079F002C1E");

            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
