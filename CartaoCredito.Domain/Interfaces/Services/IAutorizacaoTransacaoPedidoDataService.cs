using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartaoCredito.Domain.Entities;

namespace CartaoCredito.Domain.Interfaces.Services
{
    public interface IAutorizacaoTransacaoPedidoDataService: IServiceBase<AutorizacaoTransacaoPedidoData>
    {
        void Add(AutorizacaoTransacaoPedido pedido);
        AutorizacaoTransacaoPedidoData ObterResultadoAutorizacaoPorChave(string chaveTransaca);
        Task<AutorizacaoTransacaoPedidoData> ObterResultadoAutorizacaoPorChaveAsync(string chaveTransacao);
        List<AutorizacaoTransacaoPedidoData> ObterResultadoAutorizacaoPorData(DateTime dataInicio, DateTime dataFinal);
    }
}
