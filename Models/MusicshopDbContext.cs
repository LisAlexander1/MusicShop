using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MusicShop.Models;

public partial class MusicShopDbContext : DbContext
{
    public MusicShopDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Ensemble> Ensembles { get; set; }
    public DbSet<Music> Musics { get; set; }
    public DbSet<Musician> Musicians { get; set; }

    public DbSet<Disk> Disks { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<SellerCompany> SellerCompanies { get; set; }
    
    public DbSet<MusicVersion> MusicVersions { get; set; }
    public DbSet<EnsembleMembership> EnsembleMembership { get; set; }

    public DbSet<User> Users { get; set; }
    
    


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Disk>(entity =>
        {
            entity.ToTable("disk");
    
            entity.Property(e => e.Id)
                .ValueGeneratedNever();
            entity.Property(e => e.Artwork)
                .HasColumnName("artwork");
            entity.Property(e => e.CurrentYearSells)
                .HasDefaultValueSql("0")
                .HasColumnName("current_year_sells");
            entity.Property(e => e.DateRelease)
                .HasColumnType("TEXT(10, 10)")
                .HasColumnName("date_release");
            entity.Property(e => e.LastYearSells)
                .HasDefaultValueSql("0")
                .HasColumnName("last_year_sells");
            entity.Property(e => e.ManufacturerId)
                .HasColumnName("manufacturer_id");
            entity.Property(e => e.Name)
                .HasDefaultValue("0")
                .HasColumnType("TEXT(50)")
                .HasColumnName("name");
            entity.Property(e => e.RetailPrice)
                .HasColumnName("retail_price");
            entity.Property(e => e.SellerCompanyId)
                .HasColumnType("seller_company_id");
            entity.Property(e => e.WholesalePrice)
                .HasColumnName("wholesales_price");
    
            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Disks)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasOne(d => d.SellerCompany).WithMany(p => p.Disks)
                .HasForeignKey(d => d.SellerCompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entity.HasMany(d => d.Records)
                .WithMany(m => m.Disks)
                .UsingEntity<DiskRecords>(
                    j =>
                        j.HasOne(dr => dr.MusicVersion)
                            .WithMany()
                            .HasForeignKey(dr => dr.MusicVersionId),
                    j =>
                        j.HasOne(dr => dr.Disk)
                            .WithMany()
                            .HasForeignKey(dr => dr.DiskId)
                );
        });
    
        modelBuilder.Entity<Ensemble>(entity =>
        {
            entity.ToTable("Ensemble");
    
            entity.Property(e => e.Id);
            entity.Property(e => e.Name)
                .HasColumnType("TEXT(50)");
            entity.Property(e => e.Avatar)
                .HasColumnType("BLOB");
        });
    
        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("Manufacturer");
        
            entity.HasIndex(e => e.Name, "manufacturer_name_unique").IsUnique();
            entity.Property(e => e.Address);
            entity.Property(e => e.Id);
            entity.Property(e => e.Name);
        });
    
        modelBuilder.Entity<Music>(entity =>
        {
            entity.ToTable("Music");
    
            entity.Property(e => e.Id);
            entity.Property(e => e.Artwork)
                .HasColumnType("blob");
            entity.Property(e => e.MusicDuration)
                .HasColumnType("TEXT(5, 5)");
            entity.Property(e => e.Name)
                .HasColumnType("TEXT(50)");
            entity.HasMany(m => m.Authors)
                .WithMany(e => e.AuthorsMusic)
                .UsingEntity<MusicAuthors>(
                    j =>
                        j.HasOne(ma => ma.Ensemble)
                            .WithMany()
                            .HasForeignKey(ma => ma.EnsembleId),
                    j =>
                        j.HasOne(ma => ma.Music)
                            .WithMany()
                            .HasForeignKey(ma => ma.MusicId)
                    );
        });
    
        modelBuilder.Entity<MusicVersion>(entity =>
        {
            entity.ToTable("MusicVersions");
    
            entity.Property(e => e.Id);
            entity.Property(e => e.MusicId);
            entity.Property(e => e.PerformerId);
            entity.Property(e => e.Type)
                .HasColumnType("TEXT(50)")
                .HasColumnName("type");
    
            entity.HasOne(d => d.Music).WithMany(p => p.MusicVersions)
                .HasForeignKey(d => d.MusicId)
                .OnDelete(DeleteBehavior.Cascade);
    
            entity.HasOne(d => d.Performer).WithMany(p => p.MusicVersions)
                .HasForeignKey(d => d.PerformerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    
        modelBuilder.Entity<EnsembleMembership>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Roles).HasMaxLength(50);
        });
    
        modelBuilder.Entity<Musician>(entity =>
        {
            entity.ToTable("Musician");
            
            entity.Property(e => e.Id);
            entity.Property(e => e.FirstName)
                .HasColumnType("TEXT(50)");
            entity.Property(e => e.LastName)
                .HasColumnType("TEXT(50)");
            entity.Property(e => e.Surname)
                .HasColumnType("TEXT(50)");
    
            entity.Property(e => e.Avatar)
                .HasColumnType("BLOB");
        });
    
    
        modelBuilder.Entity<SellerCompany>(entity =>
        {
            entity.ToTable("SellerCompany");
    
            entity.HasIndex(e => e.Name, "seller_company_name_unique").IsUnique();
    
            entity.Property(e => e.Id);
            entity.Property(e => e.Address);
            entity.Property(e => e.Name);
        });
    
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
    
            entity.HasIndex(e => e.Login, "user_login_unique").IsUnique();
    
            entity.Property(e => e.Id);
            entity.Property(e => e.Login)
                .HasColumnType("text(5, 50)")
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasColumnType("text(50)")
                .HasColumnName("name");
            entity.Property(e => e.Password);
            entity.Property(e => e.Role);
        });
        
    }
}
