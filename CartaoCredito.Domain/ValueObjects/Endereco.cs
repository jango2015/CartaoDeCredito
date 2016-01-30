namespace CartaoCredito.Domain.ValueObjects
{
    /// <summary>
    /// Classe de dados endereço
    /// </summary>
    public class Endereco
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
    }
}
