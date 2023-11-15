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
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Service>().HasData(
        new Service { Id = 1, ServiceName = "Kleiner Service" },
        new Service { Id = 2, ServiceName = "Großer Service" },
        new Service { Id = 3, ServiceName = "Rennskiservice" },
        new Service { Id = 4, ServiceName = "Bindung montieren und einstellen" },
        new Service { Id = 5, ServiceName = "Fell zuschneiden" },
        new Service { Id = 6, ServiceName = "Heißwachsen" }
    );

            // Seed Daten für Status
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "Offen" },
                new Status { Id = 2, StatusName = "In Arbeit" },
                new Status { Id = 3, StatusName = "Abgeschlossen" },
                new Status { Id = 4, StatusName = "Storniert" }
            );

            // Seed Daten für Priorities
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, PriorityName = "Tief" },
                new Priority { Id = 2, PriorityName = "Standard" },
                new Priority { Id = 3, PriorityName = "Hoch" }
            );

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
