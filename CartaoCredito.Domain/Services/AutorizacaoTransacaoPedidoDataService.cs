using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartaoCredito.Domain.Entities;
using CartaoCredito.Domain.Interfaces.Repository;
using CartaoCredito.Domain.Interfaces.Services;

namespace CartaoCredito.Domain.Services
{
    public class AutorizacaoTransacaoPedidoDataService : ServiceBase<AutorizacaoTransacaoPedidoData>, IAutorizacaoTransacaoPedidoDataService
    {
        private readonly IAutorizacaoTransacaoPedidoDataRepository _autorizacaoTransacaoPedidoDataRepository;

        public AutorizacaoTransacaoPedidoDataService(IAutorizacaoTransacaoPedidoDataRepository autorizacaoTransacaoPedidoDataRepository)
            : base(autorizacaoTransacaoPedidoDataRepository)
        {
            _autorizacaoTransacaoPedidoDataRepository = autorizacaoTransacaoPedidoDataRepository;
        }

        public void Add(AutorizacaoTransacaoPedido pedido)
        {
            var data = new AutorizacaoTransacaoPedidoData()
            {
                ChaveDaTransacao = pedido.ChaveDaTransacao,
                Descricao = pedido.Descricao,
                DataDaTransacao = pedido.DataDaTransacao,
                NumeroDeParcelas = pedido.NumeroDeParcelas,
                Valor = pedido.Valor
            };

            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var jsonString = javaScriptSerializer.Serialize(pedido);
            data.Json = jsonString.Replace(@"\","");
            _autorizacaoTransacaoPedidoDataRepository.Add(data);
        }

         public AutorizacaoTransacaoPedidoData ObterResultadoAutorizacaoPorChave(string chaveTransacao)
         {
             return _autorizacaoTransacaoPedidoDataRepository.GetAll().FirstOrDefault(c => c.ChaveDaTransacao == chaveTransacao);
         }

        public async Task<AutorizacaoTransacaoPedidoData> ObterResultadoAutorizacaoPorChaveAsync(string chaveTransacao)
        {
            var resultado = await _autorizacaoTransacaoPedidoDataRepository.GetAllAsync();

            return resultado.FirstOrDefault(c => c.ChaveDaTransacao == chaveTransacao);
        }

        public List<AutorizacaoTransacaoPedidoData> ObterResultadoAutorizacaoPorData(DateTime dataInicio, DateTime dataFinal)
        {
            return _autorizacaoTransacaoPedidoDataRepository.GetAll().Where(c => c.DataDaTransacao >= dataInicio && c.DataDaTransacao <= dataFinal).ToList();
        }
    }
}
