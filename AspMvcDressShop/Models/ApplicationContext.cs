using Microsoft.EntityFrameworkCore;

namespace AspMvcDressShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Dress> Dresses { get; set; }

        private string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DressShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dress>().HasIndex(s => s.Name).IsUnique();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(sqlConnectionString);
        }
    }
}
