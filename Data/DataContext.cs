using granthum_api.Models;
namespace granthum_api.Data

{
    public class DataContext : DbContext
    {
        private static IConfiguration _configuration;

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base (options)
        {
            _configuration = configuration;
        }

        public DbSet<InvoiceRecord> invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseCosmos(
        "AccountEndpoint = ***REMOVED***",
        "granthum-cosmos");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceRecord>()
                .ToContainer("invoicesx")
                .HasPartitionKey(r => r.Id);
        
        }
    
    }
}

