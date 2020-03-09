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

        public CobDbContext(DbContextOptions<CobDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarteiraMap());
            builder.ApplyConfiguration(new DividaMap());
            builder.ApplyConfiguration(new DevedorMap());
        }
    }
}