using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CartaoCredito.Data.EntityConfig;
using CartaoCredito.Domain.Entities;

namespace CartaoCredito.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base("CartaoDeCredito.WebApi.Properties.Settings.Mundipagg")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<AutorizacaoTransacaoPedidoData> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new TransacaoPedidoConfig());
        }
    }
}
