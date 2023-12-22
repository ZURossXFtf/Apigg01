using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Apigg01.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Repertoire> Repertoires { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Apigg;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.IdFilm);

            entity.ToTable("Film");

            entity.Property(e => e.IdFilm).HasColumnName("id_film");
            entity.Property(e => e.IdRepertoire).HasColumnName("id_repertoire");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdRepertoireNavigation).WithMany(p => p.Films)
                .HasForeignKey(d => d.IdRepertoire)
                .HasConstraintName("FK_Film_repertoire");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.IdHall).HasName("PK__hall__B3C8469DCA2E5028");

            entity.ToTable("hall");

            entity.Property(e => e.IdHall).HasColumnName("id_hall");
            entity.Property(e => e.Availableseats).HasColumnName("availableseats");
            entity.Property(e => e.Occupiedplaces).HasColumnName("occupiedplaces");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Repertoire>(entity =>
        {
            entity.HasKey(e => e.IdRepertoire).HasName("PK__repertoi__D518C6B6F7CA44F8");

            entity.ToTable("repertoire");

            entity.Property(e => e.IdRepertoire).HasColumnName("id_repertoire");
            entity.Property(e => e.Currenttime).HasColumnName("currenttime");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PK__ticket__48C6F523270838E6");

            entity.ToTable("ticket");

            entity.Property(e => e.IdTicket).HasColumnName("id_ticket");
            entity.Property(e => e.IdFilm).HasColumnName("id_film");
            entity.Property(e => e.IdHall).HasColumnName("id_hall");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");

            entity.HasOne(d => d.IdFilmNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdFilm)
                .HasConstraintName("FK_ticket_Film");

            entity.HasOne(d => d.IdHallNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.IdHall)
                .HasConstraintName("FK_ticket_hall");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
