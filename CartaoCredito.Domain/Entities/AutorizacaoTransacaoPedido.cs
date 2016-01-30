using System;

namespace CartaoCredito.Domain.Entities
{
    public class AutorizacaoTransacaoPedido
    {
        /// <summary>
        /// Chave da transação
        /// </summary>        
        public string ChaveDaTransacao { get; set; }

        /// <summary>
        /// Valor da transação 
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// Número de parcelas da transação.
        /// </summary>        
        public double NumeroDeParcelas { get; set; }

        /// <summary>
        /// Descrição do pagamento
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Data da realização da transação
        /// </summary>
        public DateTime DataDaTransacao { get; set; }

        /// <summary>
        /// Dados do comprador
        /// </summary>
        public Comprador Comprador { get; set; }

        /// <summary>
        /// Dados do carrinhos de compra
        /// </summary>
        public CarrinhoDeCompras CarrinhoDeCompras { get; set; }

        /// <summary>
        /// Dados do cartão de crédito
        /// </summary>
        public CartaoDeCredito CartaoDeCredito { get; set; }

    }
}
