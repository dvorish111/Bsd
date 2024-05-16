using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class CampainContext : DbContext
    {
        public CampainContext()
        {
        }

        public CampainContext(DbContextOptions<CampainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Donate> Donates { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<Donor> Donors { get; set; } = null!;
        public virtual DbSet<Images> Images { get; set; } = null!;
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Desktop\\כולם\\דבורי\\אתר קופות צדקה רמות\\BSD-17-03\\DB\\CampainDB.mdf;Integrated Security=True;Connect Timeout=30;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Donate>(entity =>
            {
                entity.HasIndex(e => e.ParentTaz, "UC_ParentTaz_Donates")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ParentTaz)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Street)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.IdNeighborhoodNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdNeighborhood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdNeigh__72910220");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdStatu__1A9EF37A");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dedication)
                    .HasMaxLength(255)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Quetel)
                    .HasMaxLength(255)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.IdDonatedNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonated)
                    .HasConstraintName("FK__Donations__IdDon__2CBDA3B5");

                entity.HasOne(d => d.IdDonorNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdDon__719CDDE7");

                entity.HasOne(d => d.IdNeighborhoodNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdNeighborhood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdNei__3FD07829");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Email)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Phone)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Street)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasIndex(e => e.Id, "UQ__tmp_ms_x__3214EC069DC27615")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentType).HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName).HasMaxLength(255);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.Email, "UC_Email_Permissions")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "UC_Password_Permission")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
