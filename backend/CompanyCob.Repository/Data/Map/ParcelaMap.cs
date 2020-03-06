using CompanyCob.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCob.Repository.Data.Map
{
    public class ParcelaMap : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("Parcela");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Contrato).WithMany(c => c.Parcelas).IsRequired();
            builder.Property(p => p.ValorOriginal).IsRequired().HasColumnType("money");
            builder.Property(p => p.Vencimento).IsRequired().HasColumnType("datetime");

            /* Campos calculados não serão criados no BD */
            builder.Ignore(p => p.DiasAtraso);
            builder.Ignore(p => p.ValorJuros);
            builder.Ignore(p => p.ValorFinal);
        }
    }
}