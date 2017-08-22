using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_HelperModel
{
    public partial class HelperContext : DbContext
    {
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblPeriode> TblPeriode { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-69R5JG5\TEST;Initial Catalog=EnterpriseDB_Helper;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("Tbl_City");

                entity.Property(e => e.CityId)
                    .HasColumnName("City_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("City_Name")
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblCity)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Id_Country_Id");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("Tbl_Country");

                entity.Property(e => e.CountryId)
                    .HasColumnName("Country_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("Country_Name")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPeriode>(entity =>
            {
                entity.HasKey(e => e.PeriodeId);

                entity.ToTable("Tbl_Periode");

                entity.Property(e => e.PeriodeId)
                    .HasColumnName("Periode_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeDescription)
                    .IsRequired()
                    .HasColumnName("Periode_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeEndDate)
                    .HasColumnName("Periode_EndDate")
                    .HasColumnType("date");

                entity.Property(e => e.PeriodeStartDate)
                    .HasColumnName("Periode_StartDate")
                    .HasColumnType("date");
            });
        }
    }
}
