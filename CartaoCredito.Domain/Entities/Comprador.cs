using CartaoCredito.Domain.ValueObjects;

namespace CartaoCredito.Domain.Entities
{
    /// <summary>
    /// Classe comprador
    /// </summary>
    public class Comprador
    {
        /// <summary>
        /// Identificação do comprador
        /// </summary>
        public int CompradorId { get; set; }
        /// <summary>
        /// Nome do comprador
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Email do comprador
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Endereço do comprador
        /// </summary>
        public Endereco Endereco { get; set; }
       
    }
}
