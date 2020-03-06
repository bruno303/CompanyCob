using CompanyCob.Domain.Model;
using CompanyCob.Domain.Model.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompanyCob.Repository.Data.Map
{
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            var tipoJurosConverter = new EnumToNumberConverter<TipoJurosEnum, int>();

            builder.ToTable("Carteira");
            builder.HasKey(c => c.Id);

            // OBS: Defino o ColumnType das propriedades String porque por padrão são nvarchar.

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(300).HasColumnType("varchar(300)");
            builder.Property(c => c.RazaoSocial).IsRequired().HasMaxLength(300).HasColumnType("varchar(300)");
            builder.Property(c => c.QtdParcelasMaxima).IsRequired();
            builder.Property(c => c.TipoJuros).IsRequired().HasConversion(tipoJurosConverter);
            builder.Property(c => c.PercentualJuros).IsRequired().HasColumnType("money");
            builder.Property(c => c.Comissao).IsRequired().HasColumnType("money");
        }
    }
}