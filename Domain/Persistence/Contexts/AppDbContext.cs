using System;
using Microsoft.EntityFrameworkCore;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Extensions;


namespace PosiPrice.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //N-N
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }
        //N-N
        public DbSet<UserVote> UserVotes { get; set; }
        public DbSet<Vote> Votes { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //1 Category Entity
            builder.Entity<Category>().ToTable("Categories");
            //1 Constraints
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);

            //1 RelationShips
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //1 Initial Data

            /*builder.Entity<Category>().HasData
                (
                    new Category
                    {
                        Id = 100,
                        Name = "RTX Nvidia"

                    },
                    new Category
                    {
                        Id = 101,
                        Name = "Radeon"
                    }



               ) ;*/
            
            //2 Product Entity
            builder.Entity<Product>().ToTable("Products");
            //2 Constraints
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            //2 RelationShips


            //2 Initial Data
           /* builder.Entity<Product>().HasData
                (
                    new Product
                    {
                        Id = 100,
                        Name = "3070 TI",
                        QuantityInPackage = 1,
                        UnitOfMeasurement = EUnitOfMeasurement.Unity,
                        CategoryId = 100
                    },
                    new Product
                    {
                        Id = 101,
                        Name = "6700XT",
                        QuantityInPackage = 2,
                        UnitOfMeasurement = EUnitOfMeasurement.Liter,
                        CategoryId = 101
                    }
                );*/
            
            //3 Tag Entity
            builder.Entity<Tag>().ToTable("Tags");
            //3 Constraints
            builder.Entity<Tag>().HasKey(p => p.Id);
            builder.Entity<Tag>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            //3 Tag RelationShip
            //3 Initial Data

            // 4 ProductTagEntity

           //posible error
            builder.Entity<Product>().ToTable("ProductsTags");

            // 4  ProductTagConstraints
            builder.Entity<ProductTag>().HasKey(p => new { p.ProductId, p.TagId });
            //4 Tag RelationShip
             /// N N
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId);
            //
            builder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);
            //4 Initial Data

            //5 Naming Conventions Policy

            builder.ApplySnakeCaseNamingConvention();
            //6
            //6 User Entity
            builder.Entity<User>().ToTable("Users");
            //6 Constraints
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
           
            //6 RelationShips


            //6 Initial Data
            /* builder.Entity<Product>().HasData
                 (
                     new Product
                     {
                         Id = 100,
                         Name = "3070 TI",
                         QuantityInPackage = 1,
                         UnitOfMeasurement = EUnitOfMeasurement.Unity,
                         CategoryId = 100
                     },
                     new Product
                     {
                         Id = 101,
                         Name = "6700XT",
                         QuantityInPackage = 2,
                         UnitOfMeasurement = EUnitOfMeasurement.Liter,
                         CategoryId = 101
                     }
                 );*/
            //
            //7 Tag Entity
            builder.Entity<Vote>().ToTable("Votes");
            //7 Constraints
            builder.Entity<Vote>().HasKey(p => p.Id);
            builder.Entity<Vote>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Vote>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            //7 Tag RelationShip
            //7 Initial Data
            //
          
             /*builder.Entity<User>().HasData
                 (
                     new User
                     {
                         Id = 200,
                         Name = "Juan Peralta",
                         
                         
                         CategoryId = 1
                     }
                     
                 );*/
            //
            // 8 ProductTagEntity

            //posible error REMEM
            builder.Entity<User>().ToTable("UserVotes");

            // 8  ProductTagConstraints
            builder.Entity<UserVote>().HasKey(p => new { p.UserId, p.VoteId });
            //8 Tag RelationShip
            /// N N
            builder.Entity<UserVote>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserVotes)
                .HasForeignKey(pt => pt.UserId);
            //
            builder.Entity<UserVote>()
                .HasOne(pt => pt.Vote)
                .WithMany(t => t.UserVotes)
                .HasForeignKey(pt => pt.VoteId);
            //8 Initial Data

        }

    }
    
}