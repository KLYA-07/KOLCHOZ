using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EntityDBContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-5MBC09Q\MOPSIEZH285;Database=KOLCHOZ;User Id=sa;Password=A17B18!!C19D20;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
