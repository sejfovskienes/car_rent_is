using CarRentApp.Domain.Identity;
using CarRentApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CarRentApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for other entities
        public DbSet<RentalVehicle> RentalVehicles { get; set; }
        public DbSet<RentedVehicle> RentedVehicles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }

}
