using Microsoft.EntityFrameworkCore;
using JetstreamApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace JetstreamApi.Models
{
    public class ServiceRequestDbContext : DbContext
    {
        public ServiceRequestDbContext(DbContextOptions<ServiceRequestDbContext> options)
        : base(options)
        {
        }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
