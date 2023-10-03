using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class UniversityDBContext : IdentityDbContext<IdentityUser>  /* : DbContext*/
    {

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
        {


        }


        public DbSet<Course>  Courses { get; set; }
        public DbSet<Category>   categories { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<Product>    products { get; set; }
        public DbSet<type>   types { get; set; }
        public DbSet<ApplicationUser>   applicationUsers { get; set; }
        public DbSet<Company>   companies { get; set; }
        public DbSet<ShopingCart>    shopingCarts { get; set; }
        public DbSet<OrderHeader>     orderHeaders { get; set; }
        public DbSet<OrderDetail>     orderDetails { get; set; }
        public DbSet<service>    services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
          new Category { Id = 1, Name = "Low Lights", DisplayOrder = 1 },
          new Category { Id = 2, Name = "Average Light", DisplayOrder = 2 },
          new Category { Id = 3, Name = "Strong Light", DisplayOrder = 3 }
          );




                   modelBuilder.Entity<type>().HasData(
           new type { Id = 1, Name = "Men", DisplayOrder = 1 },
           new type { Id = 2, Name = "Woman", DisplayOrder = 2 },
           new type { Id = 3, Name = "Kides", DisplayOrder = 3 },
           new type { Id = 4, Name = "teenagers", DisplayOrder = 4 }
          );

                               modelBuilder.Entity<service>().HasData(
           new service { Id = 1, Title = "Bank Account", Description = "Our experienced advisors have a vast understanding of UAE banking regulations and procedures.", Iconservice = " <i class='bx bxs-check-shield'></i>" },
           new service { Id = 2, Title = "Licenses and Permits", Description = "Our knowledgeable team will navigate the complexities and requirements of various licenses and permits", Iconservice = " <i class='bx bxs-check-shield'></i>" },
           new service { Id = 3, Title = "Free Consultancy", Description = "Guide you through the essential steps for setting up a successful business.", Iconservice = " <i class='bx bxs-check-shield'></i>" }
           
          );



            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Red Store",
                StreetAddress = "123 Tech St",
                City = "cairo City",
                PostalCode = "12121",
                State = "IL",
                PhoneNumber = "6669990000",
                Build = "D5",
                apartmen = "33"

            },
            new Company
            {
                Id = 2,
                Name = "bubbly store",
                StreetAddress = "999 Vid St",
                City = "Vid City",
                PostalCode = "66666",
                State = "IL",
                PhoneNumber = "7779990000",
                Build = "B1",
                apartmen = "53"


            },
            new Company
            {
                Id = 3,
                Name = "Weza store for women fashion",
                StreetAddress = "999 Main St",
                City = "Lala land",
                PostalCode = "99999",
                State = "NY",
                PhoneNumber = "1113335555",
                Build = "h4",
                apartmen = "86"

            }
        );





            modelBuilder.Entity<Product>().HasData(

             new Product
             {
                 Id = 1,
                 Title = "Regular Fit Resort shirt",
                 Description = "\r\nShort-sleeved shirt in a linen and cotton weave with a resort collar, French front and open chest pocket. Yoke with darts at the back, and a straight-cut hem. Regular Fit – a classic fit with good room for movement and a gently tapered waist to create a comfortable, tailored silhouette. ",
                 Brand = "H&M",
                 Color = "White/Black striped",
                 Code = 94,
                Price = 240,
                CategoryId = 1,
                typeId = 1,

             },
             new Product
             {
                 Id = 2,
                 Title = "MAMA Straight Ankle Jeans",
                 Description = "\r\nAnkle-length jeans in washed cotton denim with fake front pockets, real back pockets and straight legs. Wide jersey panel at the waist for best fit over the tummy. ",
                 Brand = "zara",
                 Color = "white",
                 Code = 393,
                 Price = 625,
                 CategoryId = 2,
                 typeId = 1,

             },
             new Product
             {
                 Id = 3,
                 Title = "Jacket Slim Fit",
                 Description = "\r\nSingle-breasted jacket in a stretch weave with narrow notch lapels with a decorative buttonhole, a chest pocket, flap front pockets and one inner pocket. Two buttons at the front, decorative buttons at the cuffs and a single back vent. Lined. Slim fit that tapers at the chest and waist which, combined with slightly narrower sleeves, creates a fitted silhouette. ",
                 Brand = "Concret",
                 Color = "Khaki green",
                 Code = 1630,
                 Price = 2100,
                 CategoryId = 1,
                 typeId = 1,

             },
             new Product
             {
                 Id = 4,
                 Title = "Relaxed Fit Pocket-detail T-shirt",
                 Description = "\r\nT-shirt in soft cotton jersey with sleeves in contrasting colours. Relaxed fit with a round, rib-trimmed neckline, dropped shoulders, an open chest pocket and a straight-cut hem. ",
                 Brand = "zara",
                 Color = "Beige",
                 Code = 10,
                 Price = 170,
                 CategoryId = 1,
                 typeId = 1,

             }
        

             );







        }



     }
}
