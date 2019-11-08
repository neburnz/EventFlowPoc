using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace poc.eventflow
{
    public class ReadModelContext : DbContext
    {
        public ReadModelContext(DbContextOptions<ReadModelContext> options) : base(options)
        {
        }
        public DbSet<ProcesoReadModel> Procesos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcesoReadModel>();
        }
    }
}