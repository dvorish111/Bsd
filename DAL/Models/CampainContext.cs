using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace DAL.Models
{
    public partial class CampainContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CampainContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CampainContext(DbContextOptions<CampainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaigns { get; set; } = null!;
        public virtual DbSet<Donate> Donates { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<Donor> Donors { get; set; } = null!;
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var connectionString = _configuration.GetConnectionString("ConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Duration).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(1);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Donate>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(1);

                entity.Property(e => e.Street).HasMaxLength(1);

                entity.HasOne(d => d.IdNeighborhoodNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdNeighborhood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdNeigh__3A4CA8FD");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdStatu__4D5F7D71");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Dedication).HasMaxLength(255);

                entity.Property(e => e.Quetel).HasMaxLength(255);

                entity.HasOne(d => d.IdDonatedNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonated)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdDon__02FC7413");

                entity.HasOne(d => d.IdDonorNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdDon__03F0984C");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(1);

                entity.Property(e => e.Email).HasMaxLength(1);

                entity.Property(e => e.FirstName).HasMaxLength(1);

                entity.Property(e => e.LastName).HasMaxLength(1);

                entity.Property(e => e.Street).HasMaxLength(1);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(1);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ManagerName).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
