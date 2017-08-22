using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_ProductModel
{
    public partial class ProductContext : DbContext
    {
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProductCategory> TblProductCategory { get; set; }
        public virtual DbSet<TblProductHot> TblProductHot { get; set; }
        public virtual DbSet<TblProductImage> TblProductImage { get; set; }
        public virtual DbSet<TblProductRecommended> TblProductRecommended { get; set; }
        public virtual DbSet<TblProductSpecs> TblProductSpecs { get; set; }
        public virtual DbSet<TblProductVariations> TblProductVariations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-69R5JG5\TEST;Initial Catalog=EnterpriseDB_Product;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Tbl_Product");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

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

                entity.Property(e => e.ProductReview)
                    .IsRequired()
                    .HasColumnName("Product_Review")
                    .HasMaxLength(36)
                    .IsUnicode(false);

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

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("Category_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductHot>(entity =>
            {
                entity.HasKey(e => e.PHotId);

                entity.ToTable("Tbl_Product_Hot");

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

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasColumnName("Product_Image")
                    .HasColumnType("image");

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

                entity.Property(e => e.ProductVariationInStock)
                    .IsRequired()
                    .HasColumnName("Product_Variation_InStock")
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
