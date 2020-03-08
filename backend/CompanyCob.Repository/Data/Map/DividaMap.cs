using CompanyCob.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCob.Repository.Data.Map
{
    public class DividaMap : IEntityTypeConfiguration<Divida>
    {
        public void Configure(EntityTypeBuilder<Divida> builder)
        {
            builder.ToTable("Divida");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NumeroDivida).IsRequired().HasMaxLength(60).HasColumnType("varchar(60)");
            builder.HasOne(c => c.Devedor).WithMany(c => c.Dividas).HasForeignKey(divida => divida.IdDevedor).IsRequired();
            builder.HasOne(c => c.Carteira).WithMany(c => c.Dividas).HasForeignKey(divida => divida.IdCarteira).IsRequired();

            builder.Property(p => p.ValorOriginal).IsRequired().HasColumnType("money");
            builder.Property(p => p.Vencimento).IsRequired().HasColumnType("datetime");

            /* Campos calculados não serão criados no BD */
            builder.Ignore(p => p.DiasAtraso);
            builder.Ignore(p => p.ValorJuros);
            builder.Ignore(p => p.ValorFinal);
            builder.Ignore(p => p.ValorComissao);
        }
    }
}