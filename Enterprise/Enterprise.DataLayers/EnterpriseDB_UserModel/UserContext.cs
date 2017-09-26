using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_UserModel
{
    public partial class UserContext : DbContext
    {
        public virtual DbSet<TblPickUpLocation> TblPickUpLocation { get; set; }
        public virtual DbSet<TblProfileImage> TblProfileImage { get; set; }
        public virtual DbSet<TblUserCard> TblUserCard { get; set; }
        public virtual DbSet<TblUserDetails> TblUserDetails { get; set; }
        public virtual DbSet<TblUserLogin> TblUserLogin { get; set; }

        public UserContext(DbContextOptions<UserContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPickUpLocation>(entity =>
            {
                entity.HasKey(e => e.PickUpLocationId);

                entity.Property(e => e.PickUpLocationId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PickUpLocation1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpLocation2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpLocation3)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserDetail)
                    .WithMany(p => p.TblPickUpLocation)
                    .HasForeignKey(d => d.UserDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Pick_Up_Location_Tbl_User_Details");
            });

            modelBuilder.Entity<TblProfileImage>(entity =>
            {
                entity.HasKey(e => e.ProfileImageId);

                entity.Property(e => e.ProfileImageId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProfileImageName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImageUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserDetail)
                    .WithMany(p => p.TblProfileImage)
                    .HasForeignKey(d => d.UserDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Profile_Image_Tbl_User_Details");
            });

            modelBuilder.Entity<TblUserCard>(entity =>
            {
                entity.HasKey(e => e.UserCardId);

                entity.Property(e => e.UserCardId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CardOwner)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardProvider)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailsId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserDetails)
                    .WithMany(p => p.TblUserCard)
                    .HasForeignKey(d => d.UserDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_User_Card_Tbl_User_Details");
            });

            modelBuilder.Entity<TblUserDetails>(entity =>
            {
                entity.HasKey(e => e.UserDetailsId);

                entity.Property(e => e.UserDetailsId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressMain)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressSecondary)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressThird)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailMain)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailSecondary)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUserLogin>(entity =>
            {
                entity.HasKey(e => e.UserLoginId);

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Tbl_User_Login_Email")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("IX_Tbl_User_Login_Phone_Number")
                    .IsUnique();

                entity.HasIndex(e => e.UserLogin)
                    .HasName("IX_Tbl_User_Login")
                    .IsUnique();

                entity.Property(e => e.UserLoginId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserDetail)
                    .WithMany(p => p.TblUserLogin)
                    .HasForeignKey(d => d.UserDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_User_Login_Tbl_User_Details");
            });
        }
    }
}
