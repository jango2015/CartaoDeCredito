using CartaoCredito.Domain.Entities;

namespace CartaoCredito.Domain.Interfaces.Services
{
    public interface IAutorizacaoTransacaoService
    {        
        AutorizacaoTransacaoResposta ObterAutorizacao(AutorizacaoTransacaoPedido pedido);
    }
}
