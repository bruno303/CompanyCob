using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace CompanyCob.Repository.Data
{
    public class CobDbContext : DbContext
    {
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Devedor> Devedores { get; set; }
        public DbSet<Divida> Dividas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=192.168.0.136,1433;Database=companycob;User ID=sa;Password=admin!@#123");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarteiraMap());
            builder.ApplyConfiguration(new DividaMap());
            builder.ApplyConfiguration(new DevedorMap());
        }
    }
}