using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_TransactionModel
{
    public partial class TransactionContext : DbContext
    {
        public virtual DbSet<TblBalance> TblBalance { get; set; }
        public virtual DbSet<TblProductTransaction> TblProductTransaction { get; set; }
        public virtual DbSet<TblTransaction> TblTransaction { get; set; }

        public TransactionContext(DbContextOptions<TransactionContext> contextOptions):base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBalance>(entity =>
            {
                entity.HasKey(e => e.BalanceId);

                entity.ToTable("Tbl_Balance");

                entity.Property(e => e.BalanceId)
                    .HasColumnName("Balance_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailsId)
                    .IsRequired()
                    .HasColumnName("User_Details_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProductTransaction>(entity =>
            {
                entity.HasKey(e => e.ProductTransactionId);

                entity.ToTable("Tbl_Product_Transaction");

                entity.Property(e => e.ProductTransactionId)
                    .HasColumnName("Product_Transaction_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductAmount).HasColumnName("Product_Amount");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("Product_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("Transaction_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TblProductTransaction)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Product_Transaction_Tbl_Transaction");
            });

            modelBuilder.Entity<TblTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.ToTable("Tbl_Transaction");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BalanceId)
                    .IsRequired()
                    .HasColumnName("Balance_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionAmount)
                    .HasColumnName("Transaction_Amount")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.TransactionCurrency)
                    .IsRequired()
                    .HasColumnName("Transaction_Currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate)
                    .IsRequired()
                    .HasColumnName("Transaction_Date")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TransactionMethod)
                    .IsRequired()
                    .HasColumnName("Transaction_Method")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionStatus)
                    .IsRequired()
                    .HasColumnName("Transaction_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransaction)
                    .IsRequired()
                    .HasColumnName("Type_Transaction")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailsId)
                    .IsRequired()
                    .HasColumnName("User_Details_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Balance)
                    .WithMany(p => p.TblTransaction)
                    .HasForeignKey(d => d.BalanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Transaction_Tbl_Balance");
            });
        }
    }
}
