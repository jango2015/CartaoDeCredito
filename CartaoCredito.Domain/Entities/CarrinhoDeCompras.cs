using System.Collections.Generic;

namespace CartaoCredito.Domain.Entities
{
    /// <summary>
    /// Classe carrinho de compras
    /// </summary>
    public sealed class CarrinhoDeCompras
    {
        /// <summary>
        /// Lista de itens do carrinho de compras
        /// </summary>
        public ICollection<Item> Items { get; set; }

        public CarrinhoDeCompras()
        {
            Items = new List<Item>();
        }       
        
    }
}
