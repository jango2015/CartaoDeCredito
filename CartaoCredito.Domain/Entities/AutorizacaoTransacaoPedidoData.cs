using System;

namespace CartaoCredito.Domain.Entities
{
    public class AutorizacaoTransacaoPedidoData
    {
        /// <summary>
        /// Identificação 
        /// </summary>
        /// [Key]
        public int TransacaoPedidoId { get; set; }

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

        public string Json { get; set; }
    }
}
