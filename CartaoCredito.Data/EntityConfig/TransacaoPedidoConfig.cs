using System.Data.Entity.ModelConfiguration;
using CartaoCredito.Domain.Entities;

namespace CartaoCredito.Data.EntityConfig
{
    public class TransacaoPedidoConfig: EntityTypeConfiguration<AutorizacaoTransacaoPedidoData>
    {
        public TransacaoPedidoConfig()
        {
            HasKey(c => c.TransacaoPedidoId);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.NumeroDeParcelas);

            Property(c => c.Valor)
               .IsRequired();

            Property(c => c.DataDaTransacao)
               .IsRequired();

            Property(c => c.ChaveDaTransacao)
               .IsRequired();

            Property(c => c.Json).HasMaxLength(1000); 
               
        }
    }
}
