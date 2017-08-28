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

        public ProductContext(DbContextOptions<ProductContext> context):base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("Tbl_Category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.CategoryImageUrl)
                    .IsRequired()
                    .HasColumnName("Category_Image_Url")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Tbl_Product");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("Product_Description")
                    .IsUnicode(false);

                entity.Property(e => e.ProductFavorite).HasColumnName("Product_Favorite");

                entity.Property(e => e.ProductLocation).HasColumnName("Product_Location");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice)
                    .HasColumnName("Product_Price")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductRating)
                    .HasColumnName("Product_Rating")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductReview).HasColumnName("Product_Review");

                entity.Property(e => e.ProductStock).HasColumnName("Product_Stock");
            });

            modelBuilder.Entity<TblProductCategory>(entity =>
            {
                entity.HasKey(e => e.PCategoryId);

                entity.ToTable("Tbl_Product_Category");

                entity.Property(e => e.PCategoryId)
                    .HasColumnName("P_Category_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("Category_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
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

                entity.ToTable("Tbl_Product_Hot");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.PHotId)
                    .HasColumnName("P_Hot_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeId)
                    .IsRequired()
                    .HasColumnName("Periode_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
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

                entity.ToTable("Tbl_Product_Image");

                entity.Property(e => e.PImageId)
                    .HasColumnName("P_Image_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageUrl)
                    .IsRequired()
                    .HasColumnName("Product_Image_Url")
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageName)
                    .IsRequired()
                    .HasColumnName("Product_Image_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductImageSize)
                    .IsRequired()
                    .HasColumnName("Product_Image_Size");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblProductImage)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Image_Tbl_Product");
            });

            modelBuilder.Entity<TblProductRecommended>(entity =>
            {
                entity.HasKey(e => e.PRecommendId);

                entity.ToTable("Tbl_Product_Recommended");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.PRecommendId)
                    .HasColumnName("P_Recommend_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PeriodeId)
                    .IsRequired()
                    .HasColumnName("Periode_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
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

                entity.ToTable("Tbl_Product_Specs");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.PSpecId)
                    .HasColumnName("P_Spec_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSpecTitle)
                    .IsRequired()
                    .HasColumnName("Product_Spec_Title")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductSpecValue)
                    .IsRequired()
                    .HasColumnName("Product_Spec_Value")
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

                entity.ToTable("Tbl_Product_Variations");

                entity.HasIndex(e => e.ProductId);

                entity.Property(e => e.PVariationId)
                    .HasColumnName("P_Variation_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVariation)
                    .IsRequired()
                    .HasColumnName("Product_Variation")
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
