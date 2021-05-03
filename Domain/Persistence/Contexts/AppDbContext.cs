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

            builder.Entity<Category>().HasData
                (
                    new Category
                    {
                        Id = 100,
                        Name = "Fruits and Vegetables"

                    },
                    new Category
                    {
                        Id = 101,
                        Name = "Dairy"
                    }



                ) ;

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
            builder.Entity<Product>().HasData
                (
                    new Product
                    {
                        Id = 100,
                        Name = "Apple",
                        QuantityInPackage = 1,
                        UnitOfMeasurement = EUnitOfMeasurement.Unity,
                        CategoryId = 100
                    },
                    new Product
                    {
                        Id = 100,
                        Name = "Milk",
                        QuantityInPackage = 2,
                        UnitOfMeasurement = EUnitOfMeasurement.Liter,
                        CategoryId = 101
                    }
                );

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

        }
    }
    
}