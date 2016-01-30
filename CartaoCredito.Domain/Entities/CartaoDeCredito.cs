using CartaoCredito.Domain.ValueObjects;

namespace CartaoCredito.Domain.Entities
{
    /// <summary>
    /// Classe cartão de crédito
    /// </summary>
    public class CartaoDeCredito
    {
        /// <summary>
        /// Número do cartão de crédito
        /// </summary>
        public string Numero { get; set; }
        /// <summary>
        /// Nome do titular do cartão de credito
        /// </summary>   
        public string Nome { get; set; }
        /// <summary>
        /// Código de segurança - CVV
        /// </summary>
        public string CodigoDeSeguraca { get; set; }
        /// <summary>
        /// Mês de expiração do cartão de crédito
        /// </summary>
        public int MesDeExpiracao { get; set; }
        /// <summary>
        /// Ano de expiração do cartão de crédito
        /// </summary>
        public int AnoDeExpiracao { get; set; }
        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        public Bandeira Bandeira { get; set; }

    }
}
