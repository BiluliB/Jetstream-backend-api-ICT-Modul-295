using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Cryptography;

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
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Das UserName nur einmal vorkommen kann
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            //Seed Name für Passwörter und User mir ist bewusst das dies nitcht der
            //beste weg ist aber mir ist kein besserer eingefallen
            var users = new List<User>();
            var userPasswords = new Dictionary<int, string>
            {
                {1, "Password1"},
                {2, "Password2"},
                {3, "Password3"},
                {4, "Password4"},
                {5, "Password5"},
                {6, "Password6"},
                {7, "Password7"},
                {8, "Password8"},
                {9, "Password9"},
                {10, "Password10"}
            };

            foreach (var pair in userPasswords)
            {
                CreatePasswordHash(pair.Value, out byte[] passwordHash, out byte[] passwordSalt);

                users.Add(new User
                {
                    Id = pair.Key,
                    UserName = $"user{pair.Key}",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsLocked = false
                });
            }

            modelBuilder.Entity<User>().HasData(users);

            // Seed Daten für Service
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, ServiceName = "Kleiner Service", Price = 49 },
                new Service { Id = 2, ServiceName = "Großer Service", Price = 69 },
                new Service { Id = 3, ServiceName = "Rennskiservice", Price = 99 },
                new Service { Id = 4, ServiceName = "Bindung montieren und einstellen", Price = 39 },
                new Service { Id = 5, ServiceName = "Fell zuschneiden", Price = 25 },
                new Service { Id = 6, ServiceName = "Heißwachsen", Price = 18 }
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
                new Priority { Id = 1, PriorityName = "Tief", Price = 0 },
                new Priority { Id = 2, PriorityName = "Standard", Price = 5 },
                new Priority { Id = 3, PriorityName = "Hoch", Price = 10 }
            );

            // Seed Daten für ServiceRequest
            modelBuilder.Entity<ServiceRequest>().HasData(
                new ServiceRequest 
                {
                    Id = 1,
                    Firstname = "Max",
                    Lastname = "Mustermann",
                    Email = "max.mustermann@example.com",
                    Phone = "1234567890",
                    PriorityId = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(1),
                    ServiceId = 1,
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
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(2),
                    ServiceId = 2,
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
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(3),
                    ServiceId = 3,
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
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(4),
                    ServiceId = 4,
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
                    PriorityId = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(5),
                    ServiceId = 5,
                    StatusId = 1,
                    Comment = "Fünfter Kommentar"
                }
                );
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
