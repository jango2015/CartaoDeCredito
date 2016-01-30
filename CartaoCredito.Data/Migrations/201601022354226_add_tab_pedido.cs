using System.Data.Entity.Migrations;

namespace CartaoCredito.Data.Migrations
{
    public partial class add_tab_pedido : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutorizacaoTransacaoPedidoData",
                c => new
                    {
                        TransacaoPedidoId = c.Int(nullable: false, identity: true),
                        ChaveDaTransacao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Valor = c.Double(nullable: false),
                        NumeroDeParcelas = c.Double(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataDaTransacao = c.DateTime(nullable: false),
                        Json = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.TransacaoPedidoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AutorizacaoTransacaoPedidoData");
        }
    }
}
