using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JetstreamApi.Data
{
    public class ApplicationDbContext : DbContext
   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed für Services
            modelBuilder.Entity<ServiceRequest>().HasData(
                new ServiceRequest 
                {
                    Id = 1,
                    Firstname = "Max",
                    Lastname = "Mustermann",
                    Email = "max.mustermann@example.com",
                    Phone = "1234567890",
                    Priority = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(1),
                    ServiceId = 1,
                    Price = 100.00M,
                    StatusId = 1,
                    Comment = "Erster Kommentar"
                },
                new ServiceRequest
                {
                    Id = 2,
                    Firstname = "Maria",
                    Lastname = "Musterfrau",
                    Email = "maria.musterfrau@example.com",
                    Phone = "0987654321",
                    Priority = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(2),
                    ServiceId = 2,
                    Price = 80.50M,
                    StatusId = 2,
                    Comment = "Zweiter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 3,
                    Firstname = "Johannes",
                    Lastname = "Doe",
                    Email = "johannes.doe@example.com",
                    Phone = "1122334455",
                    Priority = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(3),
                    ServiceId = 3,
                    Price = 75.00M,
                    StatusId = 3,
                    Comment = "Dritter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 4,
                    Firstname = "Anna",
                    Lastname = "Beispiel",
                    Email = "anna.beispiel@example.com",
                    Phone = "2233445566",
                    Priority = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(4),
                    ServiceId = 4,
                    Price = 120.00M,
                    StatusId = 2,
                    Comment = "Vierter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 5,
                    Firstname = "Lukas",
                    Lastname = "Muster",
                    Email = "lukas.muster@example.com",
                    Phone = "3344556677",
                    Priority = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(5),
                    ServiceId = 5,
                    Price = 200.00M,
                    StatusId = 1,
                    Comment = "Fünfter Kommentar"
                }
                );
         }
    }
}
