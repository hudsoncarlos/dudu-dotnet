using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CepModelMap : IEntityTypeConfiguration<CepModel>
    {
        public void Configure(EntityTypeBuilder<CepModel> builder)
        {
            builder.Property(prop => prop.Id).HasColumnName("Id");
            builder.Property(prop => prop.bairro).HasColumnName("Bairro");
            builder.Property(prop => prop.cep).HasColumnName("Cep");
            builder.Property(prop => prop.complemento).HasColumnName("Complemento");
            builder.Property(prop => prop.ddd).HasColumnName("Ddd");
            builder.Property(prop => prop.gia).HasColumnName("Gia");
            builder.Property(prop => prop.localidade).HasColumnName("Localidade");
            builder.Property(prop => prop.logradouro).HasColumnName("Logradouro");
            builder.Property(prop => prop.siafi).HasColumnName("Siafi");
            builder.Property(prop => prop.uf).HasColumnName("Uf");
            builder.Property(prop => prop.ibge).HasColumnName("Ibge");

            builder.ToTable("itv_cep").HasKey(p => p.Id);
        }
    }
}
