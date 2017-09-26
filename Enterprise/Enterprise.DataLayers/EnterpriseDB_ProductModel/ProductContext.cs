using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class ProductContext : DbContext
    {
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductCategory> TblProductCategory { get; set; }
        public virtual DbSet<TblProductHot> TblProductHot { get; set; }
        public virtual DbSet<TblProductImage> TblProductImage { get; set; }
        public virtual DbSet<TblProductRecommended> TblProductRecommended { get; set; }
        public virtual DbSet<TblProductSpecs> TblProductSpecs { get; set; }
        public virtual DbSet<TblProductVariations> TblProductVariations { get; set; }

        public ProductContext(DbContextOptions<ProductContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryImageUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductDescription).IsUnicode(false);

                entity.Property(e => e.ProductFrontImage).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductRating).HasColumnType("decimal(18, 1)");
            });

            modelBuilder.Entity<TblProductCategory>(entity =>
            {
                entity.HasKey(e => e.PCategoryId);

                entity.Property(e => e.PCategoryId)
                    .HasColumnName("PCategoryId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProductCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Category_Tbl_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductCategory)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Category_Tbl_Product");
            });

            modelBuilder.Entity<TblProductHot>(entity =>
            {
                entity.HasKey(e => e.PHotId);

                entity.Property(e => e.PHotId)
                    .HasColumnName("PHotId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductHot)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Hot_Tbl_Product");
            });

            modelBuilder.Entity<TblProductImage>(entity =>
            {
                entity.HasKey(e => e.PImageId);

                entity.Property(e => e.PImageId)
                    .HasColumnName("PImageId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Image_Tbl_Product");
            });

            modelBuilder.Entity<TblProductRecommended>(entity =>
            {
                entity.HasKey(e => e.PRecommendId);

                entity.Property(e => e.PRecommendId)
                    .HasColumnName("PRecommendId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductRecommended)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Recommended_Tbl_Product");
            });

            modelBuilder.Entity<TblProductSpecs>(entity =>
            {
                entity.HasKey(e => e.PSpecId);

                entity.Property(e => e.PSpecId)
                    .HasColumnName("PSpecId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSpecTitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSpecValue)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductSpecs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Specs_Tbl_Product");
            });

            modelBuilder.Entity<TblProductVariations>(entity =>
            {
                entity.HasKey(e => e.PVariationId);

                entity.Property(e => e.PVariationId)
                    .HasColumnName("PVariationId")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVariation)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductVariations)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Variations_Tbl_Product");
            });
        }
    }
}
