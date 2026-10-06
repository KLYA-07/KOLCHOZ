using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
