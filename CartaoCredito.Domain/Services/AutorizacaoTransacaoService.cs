using System;
using CartaoCredito.Domain.Entities;
using CartaoCredito.Domain.Interfaces.Services;
using CartaoCredito.Domain.ValueObjects;

namespace CartaoCredito.Domain.Services
{
    public class AutorizacaoTransacaoService: IAutorizacaoTransacaoService 
    {        
        public AutorizacaoTransacaoResposta ObterAutorizacao(AutorizacaoTransacaoPedido pedido)
        {
            var resposta = new AutorizacaoTransacaoResposta();
            // Verifica o valor para autorização
            // Valor até 1000: Autorizado
            if (pedido.Valor <= 1000)
            {
                resposta.CodigoDeAutorizacao = Guid.NewGuid();
                resposta.TransacaoStatusAutorizacao = AutorizacaoTransacaoStatus.Autorizado;
            }
            //Valor de 1001 até 2000: Não Autorizado
            else if ((pedido.Valor > 1000) && (pedido.Valor <= 2000))
            {
                resposta.TransacaoStatusAutorizacao = AutorizacaoTransacaoStatus.NaoAutorizado;
            }
            //Valor de 2001 até 3000: Não Autorizado
            else if ((pedido.Valor > 2000) && (pedido.Valor <= 3000))
            {
                resposta.TransacaoStatusAutorizacao = AutorizacaoTransacaoStatus.TransacaoComErroDeProcessamento;
            }
            //Valor de 3001 até42000: Não Autorizado
            else if ((pedido.Valor > 3000) && (pedido.Valor <= 4000))
            {
                resposta.TransacaoStatusAutorizacao = AutorizacaoTransacaoStatus.PendenteDeCaptura;
            }
            else {
                resposta.TransacaoStatusAutorizacao = AutorizacaoTransacaoStatus.Erro;
            }

            resposta.ChaveDaTransacao = pedido.ChaveDaTransacao;

            return resposta;
        }

    }
}
