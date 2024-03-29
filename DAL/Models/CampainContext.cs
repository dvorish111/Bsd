﻿using System;
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
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CampainDB;Integrated Security=True;Pooling=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("Campaign");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Donate>(entity =>
            {
                entity.HasIndex(e => e.ParentTaz, "UC_ParentTaz_Donates")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.Property(e => e.ParentTaz).HasMaxLength(32);

                entity.Property(e => e.Street).HasMaxLength(32);

                entity.HasOne(d => d.IdNeighborhoodNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdNeighborhood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdNeigh__2DE6D218");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Donates)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donates__IdStatu__68487DD7");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dedication).HasMaxLength(255);

                entity.Property(e => e.Quetel).HasMaxLength(255);

                entity.HasOne(d => d.IdDonatedNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonated)
                    .HasConstraintName("FK__Donations__IdDon__2057CCD0");

                entity.HasOne(d => d.IdDonorNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdDonor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdDon__1F63A897");

                entity.HasOne(d => d.IdNeighborhoodNavigation)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.IdNeighborhood)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donations__IdNei__22401542");
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(32);

                entity.Property(e => e.Email).HasMaxLength(32);

                entity.Property(e => e.FirstName).HasMaxLength(32);

                entity.Property(e => e.LastName).HasMaxLength(32);

                entity.Property(e => e.Phone).HasMaxLength(32);

                entity.Property(e => e.Street).HasMaxLength(32);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(32);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(e => e.Email, "UC_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UC_Email_Permissions")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "UC_Password_Permissions")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.ManagerName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
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
