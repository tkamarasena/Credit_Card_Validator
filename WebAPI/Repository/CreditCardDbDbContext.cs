using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Repository.Models;

namespace WebAPI.Repository;

public partial class CreditCardDbDbContext : DbContext
{
    public CreditCardDbDbContext()
    {
    }

    public CreditCardDbDbContext(DbContextOptions<CreditCardDbDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CardType> CardTypes { get; set; }

    public virtual DbSet<ValidationRequest> ValidationRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Tharinda\\Documents\\CreditCardDb.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CardType__3214EC07C153795C");
        });

        modelBuilder.Entity<ValidationRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Validati__3214EC07502B37EF");

            entity.Property(e => e.RequestDate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
