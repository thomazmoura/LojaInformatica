using LojaInformatica.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaInformatica.Dados.Configuracao
{
    public class ClienteConfiguracao : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(cliente => cliente.Id);
            builder.Property(cliente => cliente.Nome)
                .IsRequired();
        }
    }
}