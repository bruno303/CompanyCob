using CompanyCob.Domain.Model;
using CompanyCob.Repository.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace CompanyCob.Repository.Data
{
    public class CobDbContext : DbContext
    {
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Devedor> Devedores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=companycob;User ID=sa;Password=1q2w3e%&!");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarteiraMap());
            builder.ApplyConfiguration(new ContratoMap());
            builder.ApplyConfiguration(new DevedorMap());
            builder.ApplyConfiguration(new ParcelaMap());
        }
    }
}