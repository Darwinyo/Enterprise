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

        public UserContext(DbContextOptions<UserContext> contextOptions):base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPickUpLocation>(entity =>
            {
                entity.HasKey(e => e.PickUpLocationId);

                entity.ToTable("Tbl_Pick_Up_Location");

                entity.Property(e => e.PickUpLocationId)
                    .HasColumnName("Pick_Up_Location_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PickUpLocation1)
                    .IsRequired()
                    .HasColumnName("Pick_Up_Location_1")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpLocation2)
                    .IsRequired()
                    .HasColumnName("Pick_Up_Location_2")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PickUpLocation3)
                    .IsRequired()
                    .HasColumnName("Pick_Up_Location_3")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasColumnName("User_Detail_Id")
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

                entity.ToTable("Tbl_Profile_Image");

                entity.Property(e => e.ProfileImageId)
                    .HasColumnName("Profile_Image_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProfileImageName)
                    .IsRequired()
                    .HasColumnName("Profile_Image_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImageSize).HasColumnName("Profile_Image_Size");

                entity.Property(e => e.ProfileImageUrl)
                    .IsRequired()
                    .HasColumnName("Profile_Image_Url")
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasColumnName("User_Detail_Id")
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

                entity.ToTable("Tbl_User_Card");

                entity.Property(e => e.UserCardId)
                    .HasColumnName("User_Card_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CardNumber).HasColumnName("Card_Number");

                entity.Property(e => e.CardOwner)
                    .IsRequired()
                    .HasColumnName("Card_Owner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardProvider)
                    .IsRequired()
                    .HasColumnName("Card_Provider")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CardType)
                    .IsRequired()
                    .HasColumnName("Card_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDetailsId)
                    .IsRequired()
                    .HasColumnName("User_Details_Id")
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

                entity.ToTable("Tbl_User_Details");

                entity.Property(e => e.UserDetailsId)
                    .HasColumnName("User_Details_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressMain)
                    .HasColumnName("Address_Main")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressSecondary)
                    .HasColumnName("Address_Secondary")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AddressThird)
                    .HasColumnName("Address_Third")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailMain)
                    .HasColumnName("Email_Main")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailSecondary)
                    .HasColumnName("Email_Secondary")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("Middle_Name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneMain).HasColumnName("Phone_Main");

                entity.Property(e => e.PhoneSecondary).HasColumnName("Phone_Secondary");
            });

            modelBuilder.Entity<TblUserLogin>(entity =>
            {
                entity.HasKey(e => e.UserLoginId);

                entity.ToTable("Tbl_User_Login");

                entity.Property(e => e.UserLoginId)
                    .HasColumnName("User_Login_Id")
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

                entity.Property(e => e.PhoneNumber).HasColumnName("Phone_Number");

                entity.Property(e => e.UserDetailId)
                    .IsRequired()
                    .HasColumnName("User_Detail_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasColumnName("User_Login")
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
