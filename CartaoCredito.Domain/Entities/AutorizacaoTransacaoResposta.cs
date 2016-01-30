using System;
using CartaoCredito.Domain.ValueObjects;

namespace CartaoCredito.Domain.Entities
{
    /// <summary>
    /// Resultado da transação do cartão de crédito
    /// </summary>
    public class AutorizacaoTransacaoResposta
    {
        public AutorizacaoTransacaoResposta()
        {
            
        }
        /// <summary>
        /// Código de autorização
        /// </summary>
        public Guid CodigoDeAutorizacao { get; set; }
        /// <summary>
        /// Chave da transação
        /// </summary>        
        public string ChaveDaTransacao { get; set; }
        /// <summary>
        /// Status da autorização da transação
        /// </summary>
        public AutorizacaoTransacaoStatus TransacaoStatusAutorizacao { get; set; }
   
    }
}
