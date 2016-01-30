using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CartaoCredito.Domain.Entities;
using CartaoCredito.Domain.Interfaces.Services;

namespace CartaoCredito.WebApi.Controllers
{
    [RoutePrefix("api/AutorizacaoTransacaoService")]
    public class AutorizacaoTransacaoServiceController : ApiController
    {
        readonly IAutorizacaoTransacaoService _autorizacaoTransacaoService;
        readonly IAutorizacaoTransacaoPedidoDataService _iAutorizacaoTransacaoPedidoDataService;

        public AutorizacaoTransacaoServiceController(IAutorizacaoTransacaoService autorizacaoTransacaoService,
            IAutorizacaoTransacaoPedidoDataService autorizacaoTransacaoPedidoDataService)
        {
            _autorizacaoTransacaoService = autorizacaoTransacaoService;
            _iAutorizacaoTransacaoPedidoDataService = autorizacaoTransacaoPedidoDataService;
        }

        [HttpGet]
        public IHttpActionResult GetAutorizacao(AutorizacaoTransacaoPedido pedido)
        {
            try
            {
                if (pedido == null)
                    return BadRequest();
                _iAutorizacaoTransacaoPedidoDataService.Add(pedido);
                var resposta = _autorizacaoTransacaoService.ObterAutorizacao(pedido);
                if (resposta != null)
                {
                    return Ok(resposta);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retorna dados do pedido da autorização
        /// </summary>
        /// <param name="chaveTransacao">Chave da transação</param>
        /// <returns>HttpResponseMessage</returns>    
        [HttpGet]
        [Route("GetResultadoAutorizacaoPorChave")]
        public IHttpActionResult GetResultadoAutorizacaoPorChave(string chaveTransacao)
        {
            try
            {
                if (string.IsNullOrEmpty(chaveTransacao))
                {
                    return BadRequest("Chave de transação invalida!");
                }
                var resposta = _iAutorizacaoTransacaoPedidoDataService.ObterResultadoAutorizacaoPorChave(chaveTransacao);
                if (resposta != null)
                {
                    return Ok(resposta);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Retorna dados do pedido da autorização
        /// </summary>
        /// <param name="chaveTransacao">Chave da transação</param>
        /// <returns>Task<HttpResponseMessage/></returns>
        [HttpGet]
        [Route("GetResultadoAutorizacaoPorChaveAsync")]
        public async Task<HttpResponseMessage> GetResultadoAutorizacaoPorChaveAsync(string chaveTransacao)
        {
            try
            {
                if (string.IsNullOrEmpty(chaveTransacao))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Chave de transação invalida!");
                }
                var resposta = await _iAutorizacaoTransacaoPedidoDataService.ObterResultadoAutorizacaoPorChaveAsync(chaveTransacao);
                return resposta != null ?
                    Request.CreateResponse(HttpStatusCode.OK, resposta) :
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, "Response");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error internal");
            }
        }

        /// <summary>
        /// Retorna dados do pedido da autorização
        /// </summary>
        /// <param name="dataInicio">Data inicio</param>
        /// <param name="dataFinal">Data final</param>
        /// <returns>HttpResponseMessage</returns>
        [HttpGet]
        public IHttpActionResult ObterResultadoAutorizacaoPorData(DateTime dataInicio, DateTime dataFinal)
        {
            try
            {
                if (dataInicio > dataFinal)
                {
                    return BadRequest("Data de incial deve ser menor que a data final!");
                }
                var resposta = _iAutorizacaoTransacaoPedidoDataService.ObterResultadoAutorizacaoPorData(dataInicio, dataFinal);
                if (resposta != null)
                {
                    return Ok(resposta);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
