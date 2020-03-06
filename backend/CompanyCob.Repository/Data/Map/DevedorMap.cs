using CompanyCob.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyCob.Repository.Data.Map
{
    public class DevedorMap : IEntityTypeConfiguration<Devedor>
    {
        public void Configure(EntityTypeBuilder<Devedor> builder)
        {
            builder.ToTable("Devedor");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(d => d.Cpf).IsRequired();
        }
    }
}