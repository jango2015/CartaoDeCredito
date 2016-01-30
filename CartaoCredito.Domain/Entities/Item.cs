namespace CartaoCredito.Domain.Entities
{
    /// <summary>
    /// Classe item do carrinho
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Indetificador do item
        /// </summary>
        public int ItemId { get; set; }  

        /// <summary>
        /// Nome do item
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do item
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Valor unitário do item
        /// </summary>
        public double Valor { get; set; }

        /// <summary>
        /// Valor total dos itens
        /// </summary>
        public double ValorTotal { get; set; }

        /// <summary>
        /// Quantidade de itens
        /// </summary>
        public int Quantidade { get; set; }
    }
    
}
