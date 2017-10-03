using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.Core.DataLayers.EnterpriseDB_HelperModel
{
    public partial class HelperContext : DbContext
    {
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblPeriode> TblPeriode { get; set; }

        public HelperContext(DbContextOptions<HelperContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblCity)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Id_Country_Id");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPeriode>(entity =>
            {
                entity.HasKey(e => e.PeriodeId);

                entity.Property(e => e.PeriodeId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeDescription)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodeEndDate).HasColumnType("date");

                entity.Property(e => e.PeriodeStartDate).HasColumnType("date");
            });
        }
    }
}
