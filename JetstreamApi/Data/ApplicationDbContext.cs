﻿using JetstreamApi.Common;
using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Cryptography;

namespace JetstreamApi.Data
{
    /// <summary>
    /// Database context for the Jetstream API
    /// </summary>
    public class ApplicationDbContext : DbContext
   
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">Configuration options for the database context</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        /// <summary>
        /// Configures the model for the Jetstream API database
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The UserName can only be used once
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Seed data for users
            var users = new List<User>();

            // Add admin user
            CreatePasswordHash("Password", out byte[] adminPasswordHash, out byte[] adminPasswordSalt);
            users.Add(new User
            {
                Id = 1,
                UserName = "admin",
                PasswordHash = adminPasswordHash,
                PasswordSalt = adminPasswordSalt,
                IsLocked = false,
                Role = Roles.ADMIN
            });

            // Add additional admin user (admin1)
            CreatePasswordHash("Password1", out byte[] admin1PasswordHash, out byte[] admin1PasswordSalt);
            users.Add(new User
            {
                Id = 2,
                UserName = "admin1",
                PasswordHash = admin1PasswordHash,
                PasswordSalt = admin1PasswordSalt,
                IsLocked = false,
                Role = Roles.ADMIN
            });

            // Seed data for standard users
            for (int i = 1; i <= 10; i++)
            {
                CreatePasswordHash($"Password{i}", out byte[] userPasswordHash, out byte[] userPasswordSalt);
                users.Add(new User
                {
                    Id = i + 2, // +2, because we already added two admin users
                    UserName = $"user{i}",
                    PasswordHash = userPasswordHash,
                    PasswordSalt = userPasswordSalt,
                    IsLocked = false,
                    Role = Roles.USER
                });
            }

            modelBuilder.Entity<User>().HasData(users);

            // Seed Data for Services
            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, ServiceName = "Kleiner Service", Price = 49 },
                new Service { Id = 2, ServiceName = "Großer Service", Price = 69 },
                new Service { Id = 3, ServiceName = "Rennskiservice", Price = 99 },
                new Service { Id = 4, ServiceName = "Bindung montieren und einstellen", Price = 39 },
                new Service { Id = 5, ServiceName = "Fell zuschneiden", Price = 25 },
                new Service { Id = 6, ServiceName = "Heißwachsen", Price = 18 }
            );

            // Seed Data for Statuses
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, StatusName = "Offen" },
                new Status { Id = 2, StatusName = "In Arbeit" },
                new Status { Id = 3, StatusName = "Abgeschlossen" },
                new Status { Id = 4, StatusName = "Storniert" }
            );

            // Seed Data for Priorities
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, PriorityName = "Tief", Price = 0 },
                new Priority { Id = 2, PriorityName = "Standard", Price = 5 },
                new Priority { Id = 3, PriorityName = "Hoch", Price = 10 }
            );
                        
            // Seed Data for ServiceRequests
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
                    TotalPrice_CHF = 49 + 0,
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
                    TotalPrice_CHF = 69 + 10,
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
                    TotalPrice_CHF = 99 + 10,
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
                    TotalPrice_CHF = 39 + 10,
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
                    TotalPrice_CHF = 25 + 5,
                    StatusId = 1,
                    Comment = "Fünfter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 6,
                    Firstname = "Eva",
                    Lastname = "Beispiel",
                    Email = "eva.beispiel@example.com",
                    Phone = "4455667788",
                    PriorityId = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(6),
                    ServiceId = 6,
                    TotalPrice_CHF = 18 + 5, // Heißwachsen + Standard Priorität
                    StatusId = 1,
                    Comment = "Sechster Kommentar"
                },
                new ServiceRequest
                {
                    Id = 7,
                    Firstname = "Oliver",
                    Lastname = "Müller",
                    Email = "oliver.müller@example.com",
                    Phone = "5566778899",
                    PriorityId = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(7),
                    ServiceId = 1,
                    TotalPrice_CHF = 49 + 0, // Kleiner Service + Tief Priorität
                    StatusId = 2,
                    Comment = "Siebter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 8,
                    Firstname = "Sophia",
                    Lastname = "Schmidt",
                    Email = "sophia.schmidt@example.com",
                    Phone = "6677889900",
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(8),
                    ServiceId = 2,
                    TotalPrice_CHF = 69 + 10, // Großer Service + Hoch Priorität
                    StatusId = 3,
                    Comment = "Achter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 9,
                    Firstname = "Felix",
                    Lastname = "Schneider",
                    Email = "felix.schneider@example.com",
                    Phone = "7788990011",
                    PriorityId = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(9),
                    ServiceId = 4,
                    TotalPrice_CHF = 39 + 0, // Bindung montieren + Tief Priorität
                    StatusId = 1,
                    Comment = "Neunter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 10,
                    Firstname = "Laura",
                    Lastname = "Fischer",
                    Email = "laura.fischer@example.com",
                    Phone = "8899001122",
                    PriorityId = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(10),
                    ServiceId = 5,
                    TotalPrice_CHF = 25 + 5, // Fell zuschneiden + Standard Priorität
                    StatusId = 2,
                    Comment = "Zehnter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 11,
                    Firstname = "Maximilian",
                    Lastname = "Weber",
                    Email = "maximilian.weber@example.com",
                    Phone = "9900112233",
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(11),
                    ServiceId = 1,
                    TotalPrice_CHF = 49 + 10, // Kleiner Service + Hoch Priorität
                    StatusId = 3,
                    Comment = "Elfter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 12,
                    Firstname = "Hannah",
                    Lastname = "Meier",
                    Email = "hannah.meier@example.com",
                    Phone = "9911223344",
                    PriorityId = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(12),
                    ServiceId = 3,
                    TotalPrice_CHF = 99 + 0, // Rennskiservice + Tief Priorität
                    StatusId = 1,
                    Comment = "Zwölfter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 13,
                    Firstname = "Leon",
                    Lastname = "Wagner",
                    Email = "leon.wagner@example.com",
                    Phone = "9922334455",
                    PriorityId = 2,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(13),
                    ServiceId = 2,
                    TotalPrice_CHF = 69 + 5, // Großer Service + Standard Priorität
                    StatusId = 2,
                    Comment = "Dreizehnter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 14,
                    Firstname = "Emily",
                    Lastname = "Becker",
                    Email = "emily.becker@example.com",
                    Phone = "9933445566",
                    PriorityId = 3,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(14),
                    ServiceId = 4,
                    TotalPrice_CHF = 39 + 10, // Bindung montieren + Hoch Priorität
                    StatusId = 3,
                    Comment = "Vierzehnter Kommentar"
                },
                new ServiceRequest
                {
                    Id = 15,
                    Firstname = "Noah",
                    Lastname = "Hoffmann",
                    Email = "noah.hoffmann@example.com",
                    Phone = "9944556677",
                    PriorityId = 1,
                    CreateDate = DateTime.Now,
                    PickupDate = DateTime.Now.AddDays(15),
                    ServiceId = 5,
                    TotalPrice_CHF = 25 + 0, // Fell zuschneiden + Tief Priorität
                    StatusId = 1,
                    Comment = "Fünfzehnter Kommentar"
                }
            );
        }
        /// <summary>
        /// Creates a password hash and salt for the given password
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <param name="passwordHash">The resulting password hash</param>
        /// <param name="passwordSalt">The resulting password salt</param>
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
