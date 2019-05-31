using System;
using System.Collections.Generic;
using System.Text;
using Bangazon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Order> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            modelBuilder.Entity<Order> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Order)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<Product> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            // Restrict deletion of related product when OrderProducts entry is removed
            modelBuilder.Entity<Product> ()
                .HasMany (o => o.OrderProducts)
                .WithOne (l => l.Product)
                .OnDelete (DeleteBehavior.Restrict);

            modelBuilder.Entity<PaymentType> ()
                .Property (b => b.DateCreated)
                .HasDefaultValueSql ("GETDATE()");

            ApplicationUser user = new ApplicationUser {
                FirstName = "Admina",
                LastName = "Straytor",
                StreetAddress = "123 Infinity Way",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid ().ToString ("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user2 = new ApplicationUser
            {
                FirstName = "Dom",
                LastName = "kantrude",
                StreetAddress = "5937 place",
                UserName = "xdomix52@yahoo.com",
                NormalizedUserName = "XDOMI52X@YAHOO.COM",
                Email = "xdomix52@yahoo.com",
                NormalizedEmail = "XDOMI52X@YAHOO.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash2.HashPassword(user2, "$Password1");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            ApplicationUser user3 = new ApplicationUser
            {
                FirstName = "person",
                LastName = "three",
                StreetAddress = "another place",
                UserName = "person@person.com",
                NormalizedUserName = "PERSON@PERSON.COM",
                Email = "person@person.com",
                NormalizedEmail = "PERSON@PERSON.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash3 = new PasswordHasher<ApplicationUser> ();
            user.PasswordHash = passwordHash3.HashPassword (user3, "$Password2");
            modelBuilder.Entity<ApplicationUser> ().HasData (user3);

            modelBuilder.Entity<PaymentType> ().HasData (
                new PaymentType()
                {
                    PaymentTypeId = 1,
                    UserId = user.Id,
                    Description = "American Express",
                    AccountNumber = "86753095551212"
                },
                new PaymentType()
                {
                    PaymentTypeId = 2,
                    UserId = user.Id,
                    Description = "Discover",
                    AccountNumber = "4102948572991"
                },
                 new PaymentType()
                 {
                     PaymentTypeId = 3,
                     UserId = user.Id,
                     Description = "Visa",
                     AccountNumber = "0000133700000"
                 },
                 new PaymentType()
                 {
                     PaymentTypeId = 4,
                     UserId = user.Id,
                     Description = "American Express",
                     AccountNumber = "1111800711111"
                 }
            );

            modelBuilder.Entity<ProductType> ().HasData (
                new ProductType () {
                    ProductTypeId = 1,
                        Label = "Sporting Goods"
                },
                new ProductType () {
                    ProductTypeId = 2,
                        Label = "Appliances"
                },
                 new ProductType()
                 {
                     ProductTypeId = 3,
                     Label = "Video Game"
                 },
                new ProductType()
                {
                    ProductTypeId = 4,
                    Label = "Stuff"
                }
            );

            modelBuilder.Entity<Product> ().HasData (
                new Product () {
                    ProductId = 1,
                        ProductTypeId = 1,
                        UserId = user.Id,
                        Description = "It flies high",
                        Title = "Kite",
                        Quantity = 100,
                        Price = 2.99
                },
                new Product () {
                    ProductId = 2,
                        ProductTypeId = 2,
                        UserId = user.Id,
                        Description = "It rolls fast",
                        Title = "Wheelbarrow",
                        Quantity = 5,
                        Price = 29.99
                },
                new Product()
                {
                    ProductId = 3,
                    ProductTypeId = 2,
                    UserId = user.Id,
                    Description = "Its cold yo",
                    Title = "Fridge",
                    Quantity = 5,
                    Price = 29.99
                },
                new Product()
                {
                    ProductId = 4,
                    ProductTypeId = 3,
                    UserId = user.Id,
                    Description = "Tear people in half",
                    Title = "God of War",
                    Quantity = 5,
                    Price = 29.99
                },
                 new Product()
                 {
                     ProductId = 5,
                     ProductTypeId = 4,
                     UserId = user.Id,
                     Description = "Its a thing idk",
                     Title = "something",
                     Quantity = 5,
                     Price = 29.99
                 }
            );

            modelBuilder.Entity<Order> ().HasData (
                new Order () {
                    OrderId = 1,
                    UserId = user.Id,
                    PaymentTypeId = null
                }
            );

            modelBuilder.Entity<Order>().HasData(
             new Order()
             {
                 OrderId = 2,
                 UserId = user.Id,
                 PaymentTypeId = null
             }
         );

            modelBuilder.Entity<Order>().HasData(
               new Order()
               {
                   OrderId = 3,
                   UserId = user.Id,
                   PaymentTypeId = null
               }
           );

            modelBuilder.Entity<Order>().HasData(
               new Order()
               {
                   OrderId = 4,
                   UserId = user.Id,
                   PaymentTypeId = null
               }
           );

            modelBuilder.Entity<OrderProduct> ().HasData (
                new OrderProduct () {
                    OrderProductId = 1,
                    OrderId = 1,
                    ProductId = 1
                }
            );

            modelBuilder.Entity<OrderProduct> ().HasData (
                new OrderProduct () {
                    OrderProductId = 2,
                    OrderId = 1,
                    ProductId = 2
                }
            );

            modelBuilder.Entity<OrderProduct>().HasData(
              new OrderProduct()
              {
                  OrderProductId = 3,
                  OrderId = 3,
                  ProductId = 3
              }
          );

            modelBuilder.Entity<OrderProduct>().HasData(
                new OrderProduct()
                {
                    OrderProductId = 4,
                    OrderId = 4,
                    ProductId = 4
                }
            );



        }

        public DbSet<Bangazon.Models.Profile> Profile { get; set; }
    }
}