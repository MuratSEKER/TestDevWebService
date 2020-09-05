using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDevWebService.Models
{
    public partial class TestWebAppContext : DbContext
    {
        public TestWebAppContext()
        {
        }

        public TestWebAppContext(DbContextOptions<TestWebAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.IdItem);

                entity.HasIndex(e => e.IdUser);

                entity.Property(e => e.Game)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.IdUser);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.IdProperty);

                entity.HasIndex(e => e.IdItem);

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.IdItem);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.HasIndex(e => e.UserName)
                    .HasName("UC_Name")
                    .IsUnique();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    UserName = "cecilia"
                },
                new User
                {
                    IdUser = 2,
                    UserName = "ana"
                });

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    IdItem = 1,
                    Name = "item1",
                    Game = "game1",
                    ExpirationDate = new DateTime(2012, 8, 12),
                    Quantity = 1,
                    IdUser = 1
                },
                new Item
                {
                    IdItem = 2,
                    Name = "item2",
                    Game = "game2",
                    ExpirationDate = new DateTime(2012, 8, 29),
                    Quantity = 2,
                    IdUser = 1
                },
                new Item
                {
                    IdItem = 3,
                    Name = "item3",
                    Game = "game1",
                    ExpirationDate = new DateTime(2012, 8, 20),
                    Quantity = 3,
                    IdUser = 2
                });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    IdProperty = 1,
                    Name = "name1",
                    Value = "value1",
                    IdItem = 1
                },
                new Property
                 {
                     IdProperty = 2,
                     Name = "name2",
                     Value = "value2",
                     IdItem = 1
                 },
                new Property
                  {
                      IdProperty = 3,
                      Name = "name3",
                      Value = "value3",
                      IdItem = 2
                  });
        }
    }
}
