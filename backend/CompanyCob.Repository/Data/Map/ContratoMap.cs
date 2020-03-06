using CompanyCob.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCob.Repository.Data.Map
{
    public class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("Contrato");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NumeroContrato).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.HasOne(c => c.Devedor).WithMany(c => c.Contratos).IsRequired();
            builder.HasOne(c => c.Carteira).WithMany(c => c.Contratos).IsRequired();
        }
    }
}