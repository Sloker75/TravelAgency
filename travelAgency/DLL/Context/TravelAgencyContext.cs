using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DLL.Context
{
    public class TravelAgencyContext : IdentityDbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ShowPlace> ShowPlaces { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<HotelAddress> HotelAddresses { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Excursion> Excursions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne(x => x.Employee).WithOne(x => x.User).HasForeignKey<Employee>("UserId");
            //modelBuilder.Entity<Tour>().HasOne(x => x.Hotel).WithOne();
            //modelBuilder.Entity<HotelAddress>().HasOne(x => x.Hotel).WithOne(x => x.HotelAddress);

            base.OnModelCreating(modelBuilder);
        }
    }
}
