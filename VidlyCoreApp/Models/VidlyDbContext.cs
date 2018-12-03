using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VidlyCoreApp.Areas.Identity.Data;

namespace VidlyCoreApp.Models
{
    // Design Time Factory
    public class VidlyDbContextFactory : IDesignTimeDbContextFactory<VidlyDbContext>
    {
        VidlyDbContext IDesignTimeDbContextFactory<VidlyDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VidlyDbContext>();
            optionsBuilder.UseSqlite("Data Source=vidly.db");

            return new VidlyDbContext(optionsBuilder.Options);
        }
    }

    public class VidlyDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentalTransaction> RentalTransactions { get; set; }
        public DbSet<RentedMovie> RentedMovies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<InventoryControlEntry> InventoryControl { get; set; }
        public DbSet<ContentProvider> ContentProviders { get; set; }
        public DbSet<MpaRating> MpaRatings { get; set; }

        public VidlyDbContext(DbContextOptions<VidlyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

}
