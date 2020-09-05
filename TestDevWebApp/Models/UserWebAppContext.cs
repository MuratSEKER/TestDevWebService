using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDevWebApp.Models
{
    public partial class UserWebAppContext : DbContext
    {
        public UserWebAppContext()
        {
        }

        public UserWebAppContext(DbContextOptions<UserWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__role__E5045C54DE37FA31");

                entity.ToTable("role");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.RoleDescription)
                    .HasColumnName("roleDescription")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__user__3717C9829F79FB4A");

                entity.ToTable("user");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.User)
                //    .HasForeignKey(d => d.IdRole)
                //    .HasConstraintName("FK_idUser_idRole");
            });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    IdRole = 1,
                    RoleDescription = "Admin"
                },
                new Role
                {
                    IdRole = 2,
                    RoleDescription = "Guest"
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    Username = "cecilia",
                    Password = "cecilia1",
                    IdRole = 1
                },
                new User
                {
                    IdUser=2,
                    Username="ana",
                    Password="ana1",
                    IdRole=2
                });
        }
    }
}
