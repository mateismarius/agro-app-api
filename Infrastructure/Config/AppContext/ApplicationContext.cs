using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AppContext
{
    public class ApplicationContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categorys { get; set; }
        public DbSet<ProductType>? ProductTypes { get; set; }
        public DbSet<FarmerProfile>? FarmerProfiles { get; set; }
        public DbSet<FarmerReview>? FarmerReviews { get; set; }
        public DbSet<ProductReview>? ProductReviews { get; set; }
        public DbSet<ReviewProps>? ReviewProps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
