using granthum_api.Models;
using Microsoft.Azure.Cosmos;

namespace granthum_api.Data

{
    public class DataContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public DataContext()
        {

        }

        public DataContext(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public DbSet<InvoiceRecord>? InvoiceRecords { get; set; }
        public DbSet<Project>? Projects { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseCosmos(
        _configuration.GetConnectionString("dbConnect"),
        "granthum-cosmo");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceRecord>()
                .ToContainer("InvoiceRecords")
                .HasPartitionKey(i => i.Id);

            modelBuilder.Entity<Project>()
                .ToContainer("Projects")
                .HasPartitionKey(p => p.Id);
        }


    }
}

