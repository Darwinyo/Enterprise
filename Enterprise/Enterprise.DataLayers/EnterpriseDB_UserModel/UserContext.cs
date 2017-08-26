using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Enterprise.DataLayers.EnterpriseDB_UserModel
{
    public partial class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public virtual DbSet<TblUser> TblUser { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserFirstName)
                    .HasColumnName("User_FirstName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserLastName)
                    .HasColumnName("User_LastName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
